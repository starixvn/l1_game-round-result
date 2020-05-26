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
        [ResponseCache(Duration = 15, VaryByQueryKeys = new[] { "gameType", "roundId", "userTimeZone", "date" })]
        public async Task<IActionResult> GetRoundResultAsync(GameType gameType, long roundId, string userTimeZone, DateTime date)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            //var viewModel = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo));
            return PartialView("_BigSmallRoundResult");
            //switch (gameType)
            //{
            //    case GameType.BigSmall:
            //    case GameType.BigSmallTurbo:
            //        return PartialView("_BigSmallRoundResult", viewModel);

            //    case GameType.OddEven:
            //    case GameType.OddEvenTurbo:
            //        return PartialView("_OddEvenRoundResult", viewModel);

            //    case GameType.ShakeThePlate:
            //        return PartialView("_ShakeThePlateRoundResult", viewModel);

            //    case GameType.FishPrawn:
            //        return PartialView("_FishPrawnRoundResult", viewModel);

            //    case GameType.DragonTiger:
            //        return PartialView("_DragonTigerRoundResult", viewModel);

            //    case GameType.KenoProMax:
            //        return PartialView("_KenoProMaxRoundResult", viewModel);

            //    default:
            //        throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
        }

        public async Task<IActionResult> GetData(int draw, int start, int length, GameType gameType, long roundId, string userTimeZone, DateTime date, [FromServices]IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var clientTimeZone = User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.TimeZone)?.Value;
            var timeZoneInfo = string.IsNullOrWhiteSpace(clientTimeZone) ?
                 TZConvert.GetTimeZoneInfo(userTimeZone) : TZConvert.GetTimeZoneInfo(clientTimeZone);

            var viewModel = await mediator.Send(new GetRoundResultRequest(gameType, date, roundId, timeZoneInfo));
            var data = viewModel.Skip(start).Take(length).Select(x => x.ToDataTableArray(stringLocalizer));

            return Json(new
            {
                data,
                draw,
                recordsFiltered = viewModel.Count(),
                recordsTotal = viewModel.Count()
            });
        }
    }
}