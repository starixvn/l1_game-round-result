using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("LuckyThree")]
    public class LuckyThreeTicketViewModel<Draw> : GameDrawTicketViewModel<Draw, LuckyThreeRoundResult, LuckyThreeSettlementResult>
        where Draw : LuckyThreeRound
    {
        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            var subChoices = new List<string>() { "blue3", "blue2", "red2", "red3" };
            var index = subChoices.FindIndex(c => c == choice);
            if (index >= 0)
            {
                var tagBuilder = new TagBuilder("div");
                for (var i = 3; i >= 1; i--)
                {
                    tagBuilder.InnerHtml.AppendHtml(SeBallHtmlHelper.RenderChip(index >= i));
                }
                return tagBuilder.GetHtmlString();
            }
            var betChoice = new BetLogViewModel { Choice = choice };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "LuckyThree");
        }

        protected decimal GetOdds(string choice)
        {
            return Odds[choice];
        }

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs.OrderByDescending(log => log.Time))
            {
                result.Add(BuildRow(stringLocalizer, bet));
            }

            return result;
        }

        public override decimal GetBetLogWin(BetLogViewModel bet)
        {
            var isWin = IsWinningChoice(bet.DisplayedChoice);
            return isWin ? Odds[bet.Choice] * bet.Amount : 0;
        }
    }
}