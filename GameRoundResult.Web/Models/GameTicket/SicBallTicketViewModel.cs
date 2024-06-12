using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Models.GameTicket;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SicBall")]
    public class SicBallTicketViewModel<Draw> : GameDrawTicketViewModel<Draw, SicBallRoundResult, SicBallSettlementResult>
        where Draw : SicBallRound
    {
        private List<string> MainBetChoices => new List<string> { "big", "small" };
        private List<string> SubBetChoices => new List<string> { string.Empty, "specific1", "specific2", "specific3", "specific4", "specific5", "specific6" };

        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            var index = SubBetChoices.FindIndex(c => c == choice);
            if (index > 0)
            {
                var tagBuilder = new TagBuilder("div");
                tagBuilder.InnerHtml.AppendHtml(SicBallHtmlHelper.BuildBall(index.ToString(), BallColorViewModel.GetBallColor(index)));
                return tagBuilder.GetHtmlString();
            }
            var betChoice = new BetLogViewModel { Choice = choice };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "SicBall");
        }

        protected override decimal GetOdds(string choice)
        {
            if (MainBetChoices.Contains(choice))
            {
                return Odds[choice];
            }
            var total = RoundResult?.Result[0]?.Balls.Count(ball => SubBetChoices[ball] == choice);
            return total switch
            {
                1 => Odds["single"],
                2 => Odds["double"],
                3 => Odds["triple"],
                _ => 0
            };
        }

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, bool? isFrationalFormat = false, bool convertToUSD = false, int baseCurrencyMultiplier = 1)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs.OrderByDescending(log => log.Time))
            {
                result.Add(BuildRow(stringLocalizer, bet, isFrationalFormat, convertToUSD, baseCurrencyMultiplier));
            }

            return result;
        }

        public override decimal GetBetLogWin(BetLogViewModel bet)
        {
            var isWin = MainBetChoices.Contains(bet.Choice) ? IsWinningChoice(bet.DisplayedChoice) : true;
            var odds = GetOdds(bet.Choice);
            return isWin ? odds * bet.Amount : 0;
        }
    }
}