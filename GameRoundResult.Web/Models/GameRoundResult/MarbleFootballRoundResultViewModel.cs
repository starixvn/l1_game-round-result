using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class MarbleFootballRoundResultViewModel : RoundResultViewModel
    {
        public MarbleFootballResultEntity Result { get; set; }

        public MarbleFootballSettlementResultEntity SettlementResult { get; set; }

        public MarbleFootballMatchEntity Match { get; set; }

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
            tagBuilder.AddCssClass($"football-cointoss-result");

            tagBuilder.InnerHtml.AppendHtml(result);
            return tagBuilder.GetHtmlString();
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var fulltime = Result.FirstHalf + Result.SecondHalf;
            var homeScore = fulltime.Count(score => score == 'H');
            var awayScore = fulltime.Count(score => score == 'A');

            var homeImg = new TagBuilder("img");
            homeImg.AddCssClass($"img");
            homeImg.Attributes.Add(
                "src",
                $"/scss/images/marble-football/{Match?.Home ?? "home"}.png"
            );
            homeImg.Attributes.Add("width", "50px");
            homeImg.Attributes.Add("height", "50px");

            var awayImg = new TagBuilder("img");
            awayImg.AddCssClass($"img");
            awayImg.Attributes.Add(
                "src",
                $"/scss/images/marble-football/{Match?.Away ?? "away"}.png"
            );
            awayImg.Attributes.Add("width", "50px");
            awayImg.Attributes.Add("height", "50px");

            var result = new List<string>
            {
                $"{Match?.Home ?? GetCommonText(stringLocalizer, "bet_choice_home")} &nbsp; {homeImg.GetHtmlString()} &nbsp; {homeScore}",
                $"{Match?.Away ?? GetCommonText(stringLocalizer, "bet_choice_away")} &nbsp; {awayImg.GetHtmlString()} &nbsp; {awayScore}",
            };

            return string.Join(" | ", result);
        }

        public override string GetWinningTextResult(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
        )
        {
            var winningResults = new List<string>();

            if (SettlementResult.Home)
                winningResults.Add(GetCommonText(stringLocalizer, "bet_choice_home"));
            ;

            if (SettlementResult.Away)
                winningResults.Add(GetCommonText(stringLocalizer, "bet_choice_away"));

            if (SettlementResult.Draw)
                winningResults.Add(GetCommonText(stringLocalizer, "bet_choice_draw"));

            if (SettlementResult.Over)
                winningResults.Add(GetGameText(stringLocalizer, "bet_choice_over_4.5"));

            if (SettlementResult.Under)
                winningResults.Add(GetGameText(stringLocalizer, "bet_choice_under_4.5"));

            if (SettlementResult.Odd)
                winningResults.Add(GetCommonText(stringLocalizer, "bet_choice_odd"));

            if (SettlementResult.Even)
                winningResults.Add(GetCommonText(stringLocalizer, "bet_choice_even"));

            return string.Join(", ", winningResults);
        }

        public string GetGameText(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
            string key
        )
        {
            return stringLocalizer.GetStringWithNamcespace(key, "MarbleFootball");
        }

        public string GetCommonText(
            IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
            string key
        )
        {
            return stringLocalizer.GetStringWithNamcespace(key, "Common");
        }
    }
}
