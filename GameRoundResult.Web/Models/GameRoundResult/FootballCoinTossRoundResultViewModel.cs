using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FootballCoinTossRoundResultViewModel : RoundResultViewModel
    {       
        public FootballCoinTossResult Result { get; set; }

        public FootballCoinTossSettlementResult SettlementResult { get; set; }

        public FootballCoinTossMatch Match { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetResult(stringLocalizer)} - {GetWinningCode().ToUpper()}",
               $"{GetWinningCode().ToUpper()}",
               
            };

            return result;
        }

        public virtual bool IsWin(string choice)
        {
            return choice.ToLower() == "home" ? SettlementResult.Home : SettlementResult.Away;
        }

        public string GetWinningCode()
        {
            return SettlementResult.Home ? Match.Home : Match.Away;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"");

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/football-cointoss/{this.GetWinningCode()}.png");

            tagBuilder.InnerHtml.AppendHtml(img);
            return tagBuilder.GetHtmlString();
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var key = SettlementResult.Home ? "home" : "away";            

            return GetText(stringLocalizer, key);
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "FootballCoinToss");
        }        
    }   
}