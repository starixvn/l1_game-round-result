using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.VG3;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sentry;
using TimeZoneConverter;

namespace GameRoundResult.Web.Controllers
{
    public class BetHistoryController : Controller
    {
        private const string dataProtectorKey = "game-ticket-data-key";
        private const int dataProtectorLifeTimeSecond = 30;

        private readonly IMediator mediator;
        private readonly HostConfiguration hostConfiguration;
        private readonly ITimeLimitedDataProtector dataProtector;
        private readonly ILogService logService;
        private readonly IPartnerService partnerService;
        private readonly IEnumerable<OperatorConfig> operatorConfigs;
        private readonly string systemType;
        private readonly IVG3ResultService vg3Service;

        public BetHistoryController(
            IMediator mediator,
            IDataProtectionProvider dataProtectionProvider,
            IOptions<HostConfiguration> hostConfigurationOptions,
            ILogService logService,
            IPartnerService partnerService,
            IOptions<List<OperatorConfig>> operatorConfigsOptions,
            IConfiguration configuration,
            IVG3ResultService vg3Service
            )
        {
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationOptions.Value;
            this.partnerService = partnerService;
            this.logService = logService;
            operatorConfigs = operatorConfigsOptions.Value;
            this.systemType = configuration["SystemType"];
            this.vg3Service = vg3Service;
        }

        [HttpGet]
        [Route("{culture=vi-VN}/[controller]/{queryKey}", Order = 0)]
        public async Task<IActionResult> Index(string queryKey)
        {
            try
            {
                var data = dataProtector.Unprotect(queryKey).Split("^^");
                var operatorId = data[0];
                var operatorSecret = data[1];
                var gameType = Enum.Parse<GameId>(data[2]);
                var roundId = long.Parse(data[3]);
                var playerId = int.Parse(data[4]);
                var freeBet = bool.Parse(data[5]);

                var @operator = await partnerService.Get(operatorId, operatorSecret);

                if (@operator != null)
                {
                    var viewModel = new GameTicketResultViewModel
                    {
                        GameType = gameType,
                        GameTicketResult = await GetGameTicket(gameType, roundId, playerId, operatorId, freeBet)
                    };

                    if (viewModel.GameTicketResult == null)
                    {
                        return View("GameNotSupported");
                    }

                    return View(viewModel);
                }

                return RedirectToAction("NotAuthorized", "Error");
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetAccessUrl([FromBody] BetHistoryAccessUrlRequestModel model)
        {
            var log = ConvertToLog(model);

            if (ModelState.IsValid)
            {
                var @operator = await partnerService.Get(model.Auth.OperatorId, model.Auth.OperatorSecret);

                if (@operator != null)
                {
                    if (this.isVG2System() && vg3Service.IsVG3Ticket(model))
                    {
                        try
                        {
                            var vg3Request = new VG3Request
                            {
                                Auth = vg3Service.GetVG3Authentication(),
                                GameRoundId = model.GameRoundId,
                                GameTypeId = (byte)model.GameTypeId,
                                Language = model.Language,
                                PlayerId = model.PlayerId,
                            };
                            var result = await vg3Service.GetBetDetailsURL(vg3Request);
                            log.Result = new AccessUrlResponse { RedirectUrl = result.RedirectUrl };
                            log.ResponseTimeStamp = DateTimeOffset.UtcNow;
                            await logService.LogTicketDetailRequestAsync(log);
                            return Ok(result);
                        }
                        catch (Exception ex)
                        {
                            log = ConvertToLog(model);
                            SentrySdk.CaptureException(ex);
                        }
                    }
                    else
                    {
                        var queryKey = dataProtector.Protect($"{model.Auth.OperatorId}^^{model.Auth.OperatorSecret}^^{model.GameTypeId}^^{model.GameRoundId}^^{model.PlayerId}^^{model.FreeBet}",
                            TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                        model.Language = StandardizeLanguage(model.Language);
                        var redirectUrl = Url.Action("Index", "BetHistory", new { culture = model.Language, queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);

                        log.Result = new AccessUrlResponse { RedirectUrl = redirectUrl };
                        log.ResponseTimeStamp = DateTimeOffset.UtcNow;
                        await logService.LogTicketDetailRequestAsync(log);

                        return Ok(new GameTicketAccessUrlResultModel { RedirectUrl = redirectUrl });
                    }
                }
            }

            log.ResponseTimeStamp = DateTimeOffset.UtcNow;
            log.Result = new AccessUrlResponse { Error = "BadRequest" };
            await logService.LogTicketDetailRequestAsync(log);

            return BadRequest();
        }

        private string StandardizeLanguage(string language)
        {
            if (language == "zh-CN")
            {
                return "zh-Hans";
            }
            if (language == "zh-TW")
            {
                return "zh-Hant";
            }
            return language;
        }

        private static RequestLog ConvertToLog(BetHistoryAccessUrlRequestModel model)
        => new(DateTimeOffset.UtcNow, new AccessUrlRequest
        {
            Auth = new Core.Database.Entities.AuthModel(model.Auth.OperatorId, model.Auth.OperatorSecret),
            GameTypeId = model.GameTypeId,
            GameRoundId = model.GameRoundId,
            PlayerId = model.PlayerId,
            Language = model.Language,
            FreeBet = model.FreeBet
        });

        private async Task<GameTicketViewModel> GetGameTicket(GameId gameType, long roundId, int playerId, string operatorId, bool freeBet)
        {
            var config = operatorConfigs.FirstOrDefault(x => x.OperatorId == operatorId);
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(config.TimeZone);

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, playerId, timeZoneInfo, operatorId, freeBet, systemType));
        }

        private bool isVG2System()
            => this.systemType == "VG2";
    }
}