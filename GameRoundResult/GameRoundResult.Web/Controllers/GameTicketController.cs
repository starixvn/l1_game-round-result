using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public GameTicketController(IMediator mediator, IOptionsSnapshot<List<AuthenticationClient>> clientAccessor, 
            IDataProtectionProvider dataProtectionProvider,
            IOptionsSnapshot<HostConfiguration> hostConfigurationAccessor
            )
        {
            clients = clientAccessor.Value;
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
            hostConfiguration = hostConfigurationAccessor.Value;
        }

        [HttpGet]
        [Route("{culture=vi-VN}/[controller]/{queryKey}", Order = 0)]
        public async Task<IActionResult> Index(string queryKey)
        {
            try
            {
                var data = dataProtector.Unprotect(queryKey).Split('_');
                var clientId = data[0];
                var clientKey = data[1];
                var gameType = Enum.Parse<GameType>(data[2]);
                var roundId = long.Parse(data[3]);
                var memberId = int.Parse(data[4]);

                if (!Enum.IsDefined(typeof(GameType), gameType))
                {
                    return View("GameNotSupported");
                }

                var client = GetClient(clientId, clientKey);
                if (client != null)
                {
                    var viewModel = new GameTicketResultViewModel
                    {
                        GameType = gameType,
                        GameTicketResult = await GetGameTicket(client, gameType, roundId, memberId)
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
            if (ModelState.IsValid)
            {
                var client = GetClient(model.Auth.ClientID, model.Auth.ClientKey);

                if (client != null)
                {
                    var queryKey = dataProtector.Protect($"{model.Auth.ClientID}_{model.Auth.ClientKey}_{model.GameTypeId}_{model.GameRoundId}_{model.ObCustId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));

                    var redirectUrl = Url.Action("Index", "GameTicket", new { culture = model.Language, queryKey }, hostConfiguration.Domain.Scheme, hostConfiguration.Domain.Authority);
                    return Ok(new GameTicketAccessUrlResultModel { RedirectUrl = redirectUrl });
                }
            }

            return BadRequest();
        }

        private AuthenticationClient GetClient(string clientId, string clientKey)
        {
            return clients.FirstOrDefault(x => x.Key == clientKey && clientId == x.Name && x.Name == "ONEworks");
        }

        private async Task<GameTicketViewModel> GetGameTicket(AuthenticationClient client, GameType gameType, long roundId, int memberId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(client.TimeZone);

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, memberId, timeZoneInfo));
        }
    }
}