using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class MarbleFootballTicketViewModel : GameTicketViewModel
    {
        public MarbleFootballRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<MarbleFootballBetLogViewModel> BetLogs { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            if (RoundResult?.SettlementResult == null)
            {
                return false;
            }

            return choice switch
            {
                "home" => RoundResult.SettlementResult.Home,
                "away" => RoundResult.SettlementResult.Away,
                "draw" => RoundResult.SettlementResult.Draw,
                "over" => RoundResult.SettlementResult.Over,
                "under" => RoundResult.SettlementResult.Under,
                _ => false,
            };
        }

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) ? "bold text-blue" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            return Odds[choice];
        }

        public decimal GetBetLogWin(MarbleFootballBetLogViewModel bet)
        {
            return IsWinningChoice(bet.Choice) ? GetOdds(bet.Choice) * bet.Amount : 0;
        }
    }

    public class MarbleFootballBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}
