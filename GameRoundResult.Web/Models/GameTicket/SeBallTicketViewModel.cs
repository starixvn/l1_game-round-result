using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class SeBallTicketViewModel<TRound> : GameDrawTicketViewModel<TRound, SeBallRoundResult, SeBallSettlementResult>
        where TRound : SeBall1Round
    {
        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            var subChoices = new List<string>() { "blue4", "blue3", "red2", "red3", "red4" };
            var index = subChoices.FindIndex(c => c == choice);
            if (index >= 0)
            {
                return SeBallHtmlHelper.RenderSubBetChoiceImages(index).GetHtmlString();
            }
            var betChoice = new BetLogViewModel { Choice = choice };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "SeBall");
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

    public abstract class SeBallHtmlHelper
    {
        public static TagBuilder RenderSubBetChoiceImages(int redCount)
        {
            var tagBuilder = new TagBuilder("div");
            for (var i = 0; i < redCount; i++)
            {
                tagBuilder.InnerHtml.AppendHtml(RenderChip(true));
            }
            for (var j = 0; j < 4 - redCount; j++)
            {
                tagBuilder.InnerHtml.AppendHtml(RenderChip(false));
            }
            return tagBuilder;
        }

        public static TagBuilder RenderChip(bool isRed)
        {
            var img = new TagBuilder("img");
            var color = isRed ? "red" : "blue";
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/number-games/{color}-chip.png");
            return img;
        }
    }
}