using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class SpecialSeDieTicketViewModel : GameTicketViewModel
    {
        public SpecialSeDieRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<SpecialSeDieBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal TotalRefund { get; set; }

        public decimal TotalWin => TotalBetWin > 0 ? TotalBetWin + TotalBet - TotalRefund : 0;

        public decimal WinLoss => TotalWin + TotalRefund - TotalBet;
    }

    public class SpecialSeDieBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }
    }
}