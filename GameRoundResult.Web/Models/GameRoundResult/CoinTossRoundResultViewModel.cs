using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class CoinTossRoundResultViewModel : RoundResultViewModel
    {       
        public CoinTossResult Result { get; set; }

        public CoinTossSettlementResult SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetResult(stringLocalizer)}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public virtual bool IsWin(string choice)
        {
            return choice.ToLower() == "head" ? SettlementResult.Head : SettlementResult.Tail;
        }

        public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass($"");

            var image = SettlementResult.Head ? "trump" : "biden";

            var img = new TagBuilder("img");
            img.AddCssClass($"img");
            img.Attributes.Add("src", $"/scss/images/cointoss/{image}.png");
            
            tagBuilder.InnerHtml.AppendHtml(img);   
            return tagBuilder.GetHtmlString();            
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var key = SettlementResult.Head ? "head" : "tail";            

            return GetText(stringLocalizer, key);
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "CoinToss");
        }        
    }   
}