using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FootballDiceTicketViewModel : GameTicketViewModel
    {
        public FootballDiceRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<FootballDiceBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public string GetRowBetClass(string choice)
        {
            return RoundResult.SettlementResult[choice.ToLower()] ? "bold text-blue" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            return Odds[choice];
        }

        public decimal GetBetLogWin(FootballDiceBetLogViewModel bet)
        {
            var isWin = RoundResult.SettlementResult[bet.Choice.ToLower()];

            if(isWin)
            {
                return  GetOdds(bet.Choice) * bet.Amount;
            }

            return RoundResult.SettlementResult["draw"] ? bet.Amount : 0;
        }
    }

    public class FootballDiceBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}