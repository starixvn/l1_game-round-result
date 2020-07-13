using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeZoneConverter;

namespace GameRoundResult.Web.Controllers
{
    [Authorize(Policy = "OneWordOnly")]
    public class GameTicketController : Controller
    {
        private readonly IMediator mediator;
        private readonly GameTypeLocalization gameTypeLocalization;

        public GameTicketController(IMediator mediator, GameTypeLocalization gameTypeLocalization)
        {
            this.mediator = mediator;
            this.gameTypeLocalization = gameTypeLocalization;
        }

        public IActionResult Index()
        {
            var viewModel = new GameTicketSearchViewModel
            {
                GameTypes = gameTypeLocalization.GetSelectListItems()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> GetGameTicket(GameType gameType, long roundId, int memberId)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(clientTimeZone);

            var viewModel = await mediator.Send(new GetGameTicketRequest(gameType,  roundId, memberId, timeZoneInfo));

            switch (gameType)
            {
                case GameType.BigSmall:
                case GameType.BigSmallTurbo:
                    return PartialView("_BigSmallTicket", viewModel);

                case GameType.OddEven:
                case GameType.OddEvenTurbo:
                    return PartialView("_OddEvenTicket", viewModel);

                case GameType.SeDie:
                case GameType.MiniSeDie:
                    return PartialView("_SeDieTicket", viewModel);

                case GameType.FishPrawnCrab:
                    return PartialView("_FishPrawnCrabTicket", viewModel);

                case GameType.DragonTiger:
                    return PartialView("_DragonTigerTicket", viewModel);

                case GameType.Baccarat:
                    return PartialView("_BaccaratTicket", viewModel);

                case GameType.KenoProMax:
                case GameType.KenoMax:
                case GameType.KenoMax2:
                case GameType.KenoMini:
                case GameType.KenoMini2:
                case GameType.KenoEast:
                case GameType.KenoWest:
                case GameType.KenoSouth:
                case GameType.KenoNorth:
                    return PartialView("_KenoProMaxRoundResult");

                case GameType.KenoProViet:
                    return PartialView("_KenoProVietRoundResult");
                default:
                    throw new ArgumentException(nameof(gameType));
            }
        }
    }
}
