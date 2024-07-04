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
               $"{GetFormattedResult(stringLocalizer)}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public virtual bool IsWin(string choice)
        {
            return choice.ToLower() == "home" ? SettlementResult.Home : SettlementResult.Away;
        }

        public string GetWinningCode()
        {
            var homeCode = Match?.Home?.ToUpper() ?? "Home";
            var awayCode = Match?.Away?.ToUpper() ?? "Away";
            return SettlementResult.Home ? homeCode : awayCode;            
        }

        public string GetChoiceCode(string choice)
        {
            var homeCode = Match?.Home?.ToUpper() ?? "Home";
            var awayCode = Match?.Away?.ToUpper() ?? "Away";
            return choice == "home" ? homeCode : awayCode;
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
            if (Match != null && Match.Home != null)
            {
                var img = new TagBuilder("img");
                img.AddCssClass($"img");
                img.Attributes.Add("src", $"/scss/images/football-cointoss/{this.GetWinningCode()}.png"); 
                img.Attributes.Add("width", "50px");
                img.Attributes.Add("height", "50px");
                return img.GetHtmlString() + $"&nbsp; - {GetText(stringLocalizer, GetWinningCode())}";
            }
            else
            {
                return GetText(stringLocalizer, GetWinningCode());
            }
        }

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return GetText(stringLocalizer, GetWinningCode());            
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            return stringLocalizer.GetStringWithNamcespace("glossary_" + key, "FootballCoinToss");
        }        
    }   
}