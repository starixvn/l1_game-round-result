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
using Microsoft.Extensions.Localization;
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
        public IActionResult GetRoundResult(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.BigSmall:
                case GameType.BigSmallTurbo:
                    return PartialView("_BigSmallRoundResult");

                case GameType.OddEven:
                case GameType.OddEvenTurbo:
                    return PartialView("_OddEvenRoundResult");

                case GameType.ShakeThePlate:
                    return PartialView("_ShakeThePlateRoundResult");

                case GameType.FishPrawn:
                    return PartialView("_FishPrawnRoundResult");

                case GameType.DragonTiger:
                    return PartialView("_DragonTigerRoundResult");

                case GameType.KenoProMax:
                    return PartialView("_KenoProMaxRoundResult");

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
            }
        }

        [ResponseCache(Duration = 15, VaryByQueryKeys = new[] { "start", "length", "gameType", "roundId", "userTimeZone", "date" })]
        public async Task<IActionResult> GetData(int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date, [FromServices]IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            var result = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo, start + 1, length));
            var data = result.Item2.Select(x => x.ToDataTableArray(stringLocalizer));

            return Json(new
            {
                data,
                // draw,
                recordsFiltered = result.Item1,
                recordsTotal = result.Item1
            });
        }
    }
}