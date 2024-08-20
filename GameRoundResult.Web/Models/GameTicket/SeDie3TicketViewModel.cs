using System;
using System.Collections.Generic;
using System.Text;

namespace GameRoundResult.Web.Models
{
    public class SeDie3TicketViewModel : GameTicketViewModel
    {
        public SeDie3RoundResultViewModel RoundResult { get; set; }

        public IEnumerable<SeDie3BetLogViewModel> BetLogs { get; set; }
        public decimal WinLoss => BetWin - TotalBet;

        public bool FreeBet { get; set; }

        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";
        public override bool IsWinningChoice(string choice)
        {
            if (RoundResult?.SettlementResult == null)
            {
                return false;
            }

            return choice switch
            {
                "red" => RoundResult.SettlementResult.Red,
                "white" => RoundResult.SettlementResult.White,
                "red1" => RoundResult.SettlementResult.OneRed,
                "red2" => RoundResult.SettlementResult.TwoRed,
                "red3" => RoundResult.SettlementResult.ThreeRed,
                "white3" => RoundResult.SettlementResult.ThreeWhite,
                _ => false
            };
        }

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) ? "bold bet-win-text" : string.Empty;
        }

        public string RenderChips(string choice)
        {
            int chipCount = choice switch
            {
                "red1" => 1,
                "red2" => 2,
                "red3" => 3,
                "white3" => 3,
                _ => 0
            };

            var cssClass = choice.StartsWith("red") ? "red-chip" : "white-chip";
            var oppositeCssClass = choice.StartsWith("red") ? "white-chip" : "red-chip";

            int oppositeChipCount = 3 - chipCount;

            var sb = new StringBuilder();
            for (int i = 0; i < chipCount; i++)
            {
                sb.Append($"<i class='{cssClass}'></i>");
            }

            for (int i = 0; i < oppositeChipCount; i++)
            {
                sb.Append($"<i class='{oppositeCssClass}'></i>");
            }

            return sb.ToString();
        }      
    }

    public class SeDie3BetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Red { get; set; }

        public decimal White { get; set; }

        public decimal TwoRed { get; set; }

        public decimal ThreeRed { get; set; }

        public decimal OneRed { get; set; }

        public decimal ThreeWhite { get; set; }

        public decimal BetWin { get; set; }

        public bool FreeBet { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public decimal TotalAmount { get; set; }
    }

    public class SeDie3BetLogViewModel : BetLogViewModel
    {
        public override string ChoiceKey
        {
            get
            {
                return char.ToUpper(Choice[0]) + Choice.Substring(1);
            }
        }
    }
}
