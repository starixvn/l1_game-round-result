using GameRoundResult.Web.Configuration;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class CoinTossTicketViewModel : GameTicketViewModel
    {
        public CoinTossRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public override string GetRowBetClass(string choice)
        {
            return RoundResult.IsWin(choice) ? "bold text-blue" : string.Empty;
        }

        public override decimal  GetBetLogWin(BetLogViewModel bet)
        {
            var isWin = RoundResult.IsWin(bet.Choice);
            return isWin ? Odds[bet.Choice] * bet.Amount : 0;            
        }

        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            return RoundResult.GetText(stringLocalizer, choice);
        }

        protected override decimal GetOdds(string choice)
        {
            return Odds[choice];
        }        

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, bool convertToUSD = false, int baseCurrencyMultiplier = 1)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs)
            {
                result.Add(BuildRow(stringLocalizer, bet, convertToUSD, baseCurrencyMultiplier));                     
            }

            return result;
        }       
    }   
}