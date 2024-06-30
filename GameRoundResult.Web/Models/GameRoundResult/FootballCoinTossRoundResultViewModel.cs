using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Web.Configuration;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FootballCoinTossRoundResultViewModel : RoundResultViewModel
    {       
        public FootballCoinTossResult Result { get; set; }

        public FootballCoinTossSettlementResult SettlementResult { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>(base.ToDataTableArray(stringLocalizer))
            {
               $"{GetWinningTextResult(stringLocalizer)}",
               $"{GetWinningTextResult(stringLocalizer)}",
               
            };

            return result;
        }

        public virtual bool IsWin(string choice)
        {
            return choice.ToLower() == "head" ? SettlementResult.Head : SettlementResult.Tail;
        }       

        public override string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var key = SettlementResult.Head ? "home" : "away";            

            return GetText(stringLocalizer, key);
        }

        public string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "FootballCoinToss");
        }        
    }   
}