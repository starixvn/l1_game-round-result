using System;
using System.Collections.Generic;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("MarbleFootball")]
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

            return choice.ToLower() switch
            {
                "home" => RoundResult.SettlementResult.Home,
                "away" => RoundResult.SettlementResult.Away,
                "draw" => RoundResult.SettlementResult.Draw,
                "over" => RoundResult.SettlementResult.Over,
                "under" => RoundResult.SettlementResult.Under,
                "odd" => RoundResult.SettlementResult.Odd,
                "even" => RoundResult.SettlementResult.Even,
                _ => false,
            };
        }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) ? "bold bet-win-text" : string.Empty;
        }

        public decimal GetOdds(string choice)
        {
            if (choice.ToLower() == "draw" && RoundResult.SettlementResult.Draw4 == true)
            {
                return Odds["draw4"];
            }

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
