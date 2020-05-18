using System;
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
    [Authorize]
    public class GameRoundResultController : Controller
    {
        private readonly IMediator mediator;
        private readonly GameTypeLocalization gameTypeLocalization;

        public GameRoundResultController(IMediator mediator, GameTypeLocalization gameTypeLocalization)
        {
            this.mediator = mediator;
            this.gameTypeLocalization = gameTypeLocalization;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new GameRoundResultViewModel
            {
                GameTypes = gameTypeLocalization.GetSelectListItems()
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoundResultAsync(GameType gameType, long roundId, string userTimeZone, DateTime date)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            var viewModel = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo));

            switch (gameType)
            {
                case GameType.BigSmall:
                case GameType.BigSmallTurbo:
                    return PartialView("_BigSmallRoundResult", viewModel);

                case GameType.OddEven:
                case GameType.OddEvenTurbo:
                    return PartialView("_OddEvenRoundResult", viewModel);

                case GameType.ShakeThePlate:
                    return PartialView("_ShakeThePlateRoundResult", viewModel);

                case GameType.FishPrawn:
                    return PartialView("_FishPrawnRoundResult", viewModel);

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
            }
        }
    }
}