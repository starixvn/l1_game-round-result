using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class KenoMatchTicketViewModel : GameTicketViewModel
    {
        public KenoMatchRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<KenoMatchBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal Refund { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet + Refund;  
    }

    public class KenoMatchBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal GetRefund(KenoMatchPeriodSettlementResultViewModel settlementResult)
        {
            var teamChoices = new[] { "fhBlue", "fhRed", "ftBlue", "ftRed", "liveFTBlue", "liveFTRed" };

            if (!settlementResult.Blue && !settlementResult.Red && teamChoices.Contains(Choice))
            {
                return Amount;
            }

            return 0;
        }
    }
}