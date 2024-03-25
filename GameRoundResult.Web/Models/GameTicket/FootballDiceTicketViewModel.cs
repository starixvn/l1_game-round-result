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
            var isWin = this.RoundResult.SettlementResult[choice.ToLower()];

            return isWin ? Odds[choice] : 0;
        }

        public decimal GetBetLogWin(FootballDiceBetLogViewModel bet)
        {
            var isWin = this.RoundResult.SettlementResult[bet.Choice.ToLower()];
            return isWin ? GetOdds(bet.Choice) * bet.Amount : 0;
        }
    }

    public class FootballDiceBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}