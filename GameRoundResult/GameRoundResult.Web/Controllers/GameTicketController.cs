using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TimeZoneConverter;

namespace GameRoundResult.Web.Controllers
{
    public class GameTicketController : Controller
    {
        private readonly IMediator mediator;
        private readonly IEnumerable<AuthenticationClient> clients;

        public GameTicketController(IMediator mediator, IOptionsSnapshot<List<AuthenticationClient>> clientAccessor)
        {
            clients = clientAccessor.Value;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(string key, GameType gameType, long roundId, int memberId)
        {
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

        private AuthenticationClient GetClient(string key)
        {
            return clients.FirstOrDefault(x => x.Key == key && x.Name == "OneWord");
        }

        private async Task<GameTicketViewModel> GetGameTicket(AuthenticationClient client, GameType gameType, long roundId, int memberId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(client.TimeZone);

            return await mediator.Send(new GetGameTicketRequest(gameType, roundId, memberId, timeZoneInfo));
        }
    }
}