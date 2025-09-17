using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class SoccerPinGoalRoundResultViewModel : RoundResultViewModel
    {
        private const string tolgeeNameSpace = "SoccerPinGoal";

        public SoccerPinGoalResultEntity Result { get; set; }

        public SoccerPinGoalSettlementResultEntity SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
        )
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
                $"{GetFormattedResult(stringLocalizer)}",
                $"{GetWinningTextResult(stringLocalizer)}",
            };

            return result;
        }

        public string GetFormattedResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetResult(stringLocalizer);
        }

        private string GetRedBlueContent(int redValue, int blueValue)
        {
            var resultBuilder = new TagBuilder("span");
            var dividerBuilder = new TagBuilder("span");
            var redBuilder = new TagBuilder("span");
            var blueBuilder = new TagBuilder("span");

            resultBuilder.AddCssClass($"marble-football-result marble-football-result-container");
            dividerBuilder.AddCssClass("marble-football-divider");

            if (SettlementResult.Red)
            {
                redBuilder.AddCssClass("bet-win-text");
            }

            if (SettlementResult.Blue)
            {
                blueBuilder.AddCssClass("bet-win-text");
            }

            redBuilder.InnerHtml.AppendHtml($"{redValue}");
            blueBuilder.InnerHtml.AppendHtml($"{blueValue}");
            dividerBuilder.InnerHtml.Append("|");

            resultBuilder.InnerHtml.AppendHtml(redBuilder.GetHtmlString());
            resultBuilder.InnerHtml.AppendHtml(dividerBuilder.GetHtmlString());
            resultBuilder.InnerHtml.AppendHtml(blueBuilder.GetHtmlString());



            return resultBuilder.GetHtmlString();
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetRedBlueContent(Result.Red, Result.Blue);
        }

        public string GetTunnelSelection(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetRedBlueContent(Result.RedTunnel, Result.BlueTunnel);
        }

        public override string GetWinningTextResult(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
        )
        {
            var winningResults = new List<string>();

            if (SettlementResult.Red)
            {
                winningResults.Add(GetGameText(stringLocalizer, "glossary_red"));
            }

            if (SettlementResult.Blue)
            {
                winningResults.Add(GetGameText(stringLocalizer, "glossary_blue"));
            }

            if (SettlementResult.Draw)
            {
                winningResults.Add(GetGameText(stringLocalizer, "glossary_draw"));
            }

            return string.Join(", ", winningResults);
        }

        public static string GetGameText(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
            string key
        )
        {
            return stringLocalizer.GetStringWithNamcespace(key, tolgeeNameSpace);
        }
    }
}
