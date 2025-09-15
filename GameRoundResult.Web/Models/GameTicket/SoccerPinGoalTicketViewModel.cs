using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SoccerPinGoal")]
    public class SoccerPinGoalTicketViewModel : GameTicketViewModel
    {
        public SoccerPinGoalRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<SoccerPinGoalBetLogViewModel> BetLogs { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            if (RoundResult?.SettlementResult == null)
            {
                return false;
            }

            return choice.ToLower(CultureInfo.InvariantCulture) switch
            {
                "red" => RoundResult.SettlementResult.Red,
                "blue" => RoundResult.SettlementResult.Blue,
                "draw" => RoundResult.SettlementResult.Draw,
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
            return Odds.ContainsKey(choice) ? Odds[choice] : 0;
        }

        public decimal GetBetLogWin(MarbleFootball2BetLogViewModel bet)
        {
            return IsWinningChoice(bet.Choice) ? GetOdds(bet.Choice) * bet.Amount : 0;
        }
    }

    public class SoccerPinGoalBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}
