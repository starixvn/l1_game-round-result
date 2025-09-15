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

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var resultBuilder = new TagBuilder("span");

            var redResult = $"Red: {Result.Red} - Tunnel: {Result.RedTunnel}";
            var blueResult = $"Blue: {Result.Blue} - Tunnel: {Result.BlueTunnel}";

            resultBuilder.InnerHtml.AppendHtml(redResult);
            resultBuilder.InnerHtml.AppendHtml(blueResult);

            return resultBuilder.GetHtmlString();
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
