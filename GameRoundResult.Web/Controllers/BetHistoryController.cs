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
        private readonly IMediator mediator;
        private readonly HostConfiguration hostConfiguration;
        private readonly ITimeLimitedDataProtector dataProtector;
        private const string dataProtectorKey = "game-ticket-data-key";
        private const int dataProtectorLifeTimeSecond = 30;
        private readonly ILogService logService;
        private readonly IPartnerService partnerService;
        private readonly IEnumerable<OperatorConfig> operatorConfigs;
        private readonly string systemType;

        public BetHistoryController(IMediator mediator,
            IDataProtectionProvider dataProtectionProvider,
            IOptionsSnapshot<HostConfiguration> hostConfigurationAccessor,
            ILogService logService,
            IPartnerService partnerService,
            IOptionsSnapshot<List<OperatorConfig>> operatorConfigsAccessor,
            IConfiguration configuration
            )
        {
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationAccessor.Value;
            this.partnerService = partnerService;
            this.logService = logService;
            operatorConfigs = operatorConfigsAccessor.Value;
            this.systemType = configuration["SystemType"];
        }

        [HttpGet]
        [Route("{culture=vi-VN}/[controller]/{queryKey}", Order = 0)]
        public async Task<IActionResult> Index(string queryKey)
        {
            try
            {
                var data = dataProtector.Unprotect(queryKey).Split('_');
                var operatorId = data[0];
                var operatorSecret = data[1];
                var gameType = Enum.Parse<GameType>(data[2]);
                var roundId = long.Parse(data[3]);
                var playerId = int.Parse(data[4]);
                var freeBet = bool.Parse(data[5]);

                if (!Enum.IsDefined(typeof(GameType), gameType))
                {
                    return View("GameNotSupported");
                }

                var @operator = await partnerService.Get(operatorId, operatorSecret);

                if (@operator != null)
                {
                    var viewModel = new GameTicketResultViewModel
                    {
                        GameType = gameType,
                        GameTicketResult = await GetGameTicket(gameType, roundId, playerId, operatorId, freeBet)
                    };

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
                    var queryKey = dataProtector.Protect($"{model.Auth.OperatorId}_{model.Auth.OperatorSecret}_{model.GameTypeId}_{model.GameRoundId}_{model.PlayerId}_{model.FreeBet}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));

                    var redirectUrl = Url.Action("Index", "BetHistory", new { culture = model.Language, queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);

                    log.Result = new AccessUrlResponse { RedirectUrl = redirectUrl };
                    log.ResponseTimeStamp = DateTimeOffset.UtcNow;
                    await logService.LogTicketDetailRequestAsync(log);

                    return Ok(new GameTicketAccessUrlResultModel { RedirectUrl = redirectUrl });
                }
            }

            log.ResponseTimeStamp = DateTimeOffset.UtcNow;
            log.Result = new AccessUrlResponse { Error = "BadRequest" };
            await logService.LogTicketDetailRequestAsync(log);

            return BadRequest();
        }

        private static RequestLog ConvertToLog(BetHistoryAccessUrlRequestModel model)
        => new RequestLog(DateTimeOffset.UtcNow, new AccessUrlRequest
        {
            Auth = new Core.Database.Entities.AuthModel(model.Auth.OperatorId, model.Auth.OperatorSecret),
            GameTypeId = model.GameTypeId,
            GameRoundId = model.GameRoundId,
            PlayerId = model.PlayerId,
            Language = model.Language,
            FreeBet = model.FreeBet
        });

        private async Task<GameTicketViewModel> GetGameTicket(GameType gameType, long roundId, int playerId, string operatorId, bool freeBet)
        {
            var config = operatorConfigs.FirstOrDefault(x => x.OperatorId == operatorId);
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(config.TimeZone);

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, playerId, timeZoneInfo, operatorId, freeBet, systemType));
        }
    }
}