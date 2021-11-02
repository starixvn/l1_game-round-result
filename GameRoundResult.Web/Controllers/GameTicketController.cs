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
using Microsoft.Extensions.Options;
using Sentry;
using TimeZoneConverter;

namespace GameRoundResult.Web.Controllers
{
    public class GameTicketController : Controller
    {
        private readonly IMediator mediator;
        private readonly IEnumerable<AuthenticationClient> clients;
        private readonly HostConfiguration hostConfiguration;
        private readonly ITimeLimitedDataProtector dataProtector;
        private const string dataProtectorKey = "game-ticket-data-key";
        private const int dataProtectorLifeTimeSecond = 30;
        private readonly ILogService logService;

        public GameTicketController(IMediator mediator, IOptionsSnapshot<List<AuthenticationClient>> clientAccessor,
            IDataProtectionProvider dataProtectionProvider,
            IOptionsSnapshot<HostConfiguration> hostConfigurationAccessor,
            ILogService logService
            )
        {
            clients = clientAccessor.Value;
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationAccessor.Value;
            this.logService = logService;
        }

        [HttpGet]
        [Route("{culture=vi-VN}/[controller]/{queryKey}", Order = 0)]
        public async Task<IActionResult> Index(string queryKey, [FromServices] IPartnerService partnerService)
        {
            try
            {
                var data = dataProtector.Unprotect(queryKey).Split('_');
                var partnerId = data[0];
                var partnerSecret = data[1];
                var gameType = Enum.Parse<GameType>(data[2]);
                var roundId = long.Parse(data[3]);
                var memberId = int.Parse(data[4]);

                if (!Enum.IsDefined(typeof(GameType), gameType))
                {
                    return View("GameNotSupported");
                }

                var client = GetClient(partnerId, partnerSecret);
                var partner = await partnerService.Get(clientId, clientKey);

                if (client != null || partner != null)
                {
                    var viewModel = new GameTicketResultViewModel
                    {
                        GameType = gameType,
                        GameTicketResult = await GetGameTicket(gameType, roundId, memberId)
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
        public IActionResult GetAccessUrl([FromBody] GameTicketAccessUrlRequestModel model)
        {
            var log = ConvertToLog(model);

            if (ModelState.IsValid)
            {
                var client = GetClient(model.Auth.PartnerId, model.Auth.PartnerSecret);

                if (client != null)
                {
                    var queryKey = dataProtector.Protect($"{model.Auth.PartnerId}_{model.Auth.PartnerSecret}_{model.GameTypeId}_{model.GameRoundId}_{model.ObCustId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));

                    var redirectUrl = Url.Action("Index", "GameTicket", new { culture = model.Language, queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);

                    log.Result = new AccessUrlResponse { RedirectUrl = redirectUrl };
                    log.ResponseTimeStamp = DateTimeOffset.UtcNow;
                    logService.LogTicketDetailRequestAsync(log);

                    return Ok(new GameTicketAccessUrlResultModel { RedirectUrl = redirectUrl });
                }
            }

            log.ResponseTimeStamp = DateTimeOffset.UtcNow;
            log.Result = new AccessUrlResponse { Error = "BadRequest" };
            logService.LogTicketDetailRequestAsync(log);

            return BadRequest();
        }

        private static RequestLog ConvertToLog(GameTicketAccessUrlRequestModel model)
        => new RequestLog(DateTimeOffset.UtcNow, new AccessUrlRequest
        {
            Auth = new Core.Database.Entities.AuthModel(model.Auth.PartnerId, model.Auth.PartnerSecret),
            GameTypeId = model.GameTypeId,
            GameRoundId = model.GameRoundId,
            ObCustId = model.ObCustId,
            Language = model.Language,
        });

        private AuthenticationClient GetClient(string partnerId, string partnerSecret)
        {
            return clients.FirstOrDefault(x => x.Key == partnerSecret && partnerId == x.Name && x.Name == "ONEworks1");
        }

        private async Task<GameTicketViewModel> GetGameTicket(GameType gameType, long roundId, int memberId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo("SA Western Standard Time");

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, memberId, timeZoneInfo));
        }
    }
}