using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameRoundResult.Web.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using MediatR;
using GameRoundResult.Web.Requests;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Controllers
{
    public class GameRoundResultController : Controller
    {
        private readonly IMediator mediator;

        public GameRoundResultController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new GameRoundResultViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoundResultAsync(byte gameTypeId, long roundId, DateTimeOffset date)
        {
            var viewModel = await mediator.Send(new GetRoundResultRequest(gameTypeId, date.UtcDateTime, roundId));

            switch (gameTypeId)
            {
                case (byte)GameType.BigSmall:
                case (byte)GameType.BigSmallTurbo:
                    return PartialView("_BigSmallRoundResult", viewModel);

                case (byte)GameType.OddEven:
                case (byte)GameType.OddEvenTurbo:
                    return PartialView("_OddEvenRoundResult", viewModel);

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameTypeId));
            }
        }
    }
}