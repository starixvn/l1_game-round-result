using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class UnbalancedBigSmallTicketViewModel : GameTicketViewModel
    {
        public BigSmallRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<UnbalancedBigSmallBetLogViewModel> BetLogs { get; set; }

        public decimal TotalBetAmount { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBetAmount;
    }

    public class UnbalancedBigSmallBetLogViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}