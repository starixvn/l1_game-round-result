using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
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
        private readonly ITimeLimitedDataProtector dataProtector;
        private const string dataProtectorKey = "game-ticket-data-key";
        private const int dataProtectorLifeTimeSecond = 30;

        public GameTicketController(IMediator mediator, IOptionsSnapshot<List<AuthenticationClient>> clientAccessor, IDataProtectionProvider dataProtectionProvider)
        {
            clients = clientAccessor.Value;
            this.mediator = mediator;
            dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKey).ToTimeLimitedDataProtector();
        }

        [HttpGet]
        [Route("[controller]/{queryKey}", Order = 1)]
        [Route("{culture}/[controller]/{queryKey}", Order = 2)]
        public async Task<IActionResult> Index(string queryKey)
        {
            try
            {
                var data = dataProtector.Unprotect(queryKey).Split('_');
                var key = data[0];
                var gameType = Enum.Parse<GameType>(data[1]);
                var roundId = long.Parse(data[2]);
                var memberId = int.Parse(data[3]);

                if(gameType == 0)
                {
                    return View("GameNotSupported");
                }

                var client = GetClient(key);
                if (client != null)
                {
                    var viewModel = new GameTicketSearchViewModel
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
        public IActionResult QueryKey([FromBody] GameTicketQueryKeyModel model)
        {
            if (ModelState.IsValid)
            {
                var client = GetClient(model.Key);

                if (client != null)
                {
                    var queryKey = dataProtector.Protect($"{model.Key}_{model.GameTypeId}_{model.RoundId}_{model.MemberId}",
                        TimeSpan.FromSeconds(dataProtectorLifeTimeSecond));
                    return Ok(queryKey);
                }
            }

            return BadRequest();
        }

        private AuthenticationClient GetClient(string key)
        {
            return clients.FirstOrDefault(x => x.Key == key && x.Name == "OneWorks");
        }

        private async Task<GameTicketViewModel> GetGameTicket(AuthenticationClient client, GameType gameType, long roundId, int memberId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(client.TimeZone);

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, memberId, timeZoneInfo));
        }
    }
}