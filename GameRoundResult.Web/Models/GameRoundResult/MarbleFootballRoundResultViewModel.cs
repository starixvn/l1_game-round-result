using System.Collections.Generic;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class MarbleFootballRoundResultViewModel : RoundResultViewModel
    {
        public MarbleFootballResultEntity Result { get; set; }

        public MarbleFootballSettlementResultEntity SettlementResult { get; set; }

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
            var result = GetResult(stringLocalizer);
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass($"marble-football-result");

            tagBuilder.InnerHtml.AppendHtml(result);
            return tagBuilder.GetHtmlString();
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>
            {
                $"{GetText(stringLocalizer, "FirstHalf")} : {Result.FirstHalf}",
                $"{GetText(stringLocalizer, "SecondHalf")} : {Result.SecondHalf}",
            };

            return string.Join("; ", result);
        }

        public override string GetWinningTextResult(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
        )
        {
            var winningResults = new List<string>();

            if (SettlementResult.Home)
                winningResults.Add(stringLocalizer["Home"]);

            if (SettlementResult.Away)
                winningResults.Add(stringLocalizer["Away"]);

            if (SettlementResult.Draw)
                winningResults.Add(stringLocalizer["Draw"]);

            if (SettlementResult.Over)
                winningResults.Add(stringLocalizer["Over"]);

            if (SettlementResult.Under)
                winningResults.Add(stringLocalizer["Under"]);

            return string.Join(", ", winningResults);
        }


        public string GetText(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
            string key
        )
        {
            return stringLocalizer.GetStringWithNamcespace(key, "MarbleFootball");
        }
    }
}
