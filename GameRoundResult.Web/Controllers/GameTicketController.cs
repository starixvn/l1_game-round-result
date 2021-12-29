using System;
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
        private readonly HostConfiguration hostConfiguration;
        private readonly ITimeLimitedDataProtector dataProtector;
        private const string dataProtectorKey = "game-ticket-data-key";
        private const int dataProtectorLifeTimeSecond = 30;
        private readonly ILogService logService;
        private readonly IPartnerService partnerService;

        public GameTicketController(IMediator mediator,
            IDataProtectionProvider dataProtectionProvider,
            IOptionsSnapshot<HostConfiguration> hostConfigurationAccessor,
            ILogService logService,
            IPartnerService partnerService
            )
        {
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationAccessor.Value;
            this.partnerService = partnerService;
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

                var partner = await partnerService.Get(partnerId, partnerSecret);

                if (partner != null)
                {
                    var viewModel = new GameTicketResultViewModel
                    {
                        GameType = gameType,
                        GameTicketResult = await GetGameTicket(gameType, roundId, memberId, partnerId)
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
        public async Task<IActionResult> GetAccessUrl([FromBody] GameTicketAccessUrlRequestModel model)
        {
            var log = ConvertToLog(model);

            if (ModelState.IsValid)
            {
                var partner = await partnerService.Get(model.Auth.PartnerId, model.Auth.PartnerSecret);

                if (partner != null)
                {
                    var queryKey = dataProtector.Protect($"{model.Auth.PartnerId}_{model.Auth.PartnerSecret}_{model.GameTypeId}_{model.GameRoundId}_{model.ObCustId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));

                    var redirectUrl = Url.Action("Index", "GameTicket", new { culture = model.Language, queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);

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

        private static RequestLog ConvertToLog(GameTicketAccessUrlRequestModel model)
        => new RequestLog(DateTimeOffset.UtcNow, new AccessUrlRequest
        {
            Auth = new Core.Database.Entities.AuthModel(model.Auth.PartnerId, model.Auth.PartnerSecret),
            GameTypeId = model.GameTypeId,
            GameRoundId = model.GameRoundId,
            ObCustId = model.ObCustId,
            Language = model.Language,
        });

        private async Task<GameTicketViewModel> GetGameTicket(GameType gameType, long roundId, int memberId, string partnerId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo("SA Western Standard Time");

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, memberId, timeZoneInfo, partnerId));
        }
    }
}