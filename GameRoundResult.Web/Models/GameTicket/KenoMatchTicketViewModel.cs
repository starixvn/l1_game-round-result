using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class KenoMatchTicketViewModel : GameTicketViewModel
    {
        public KenoMatchRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<KenoMatchBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;
    }

    public class KenoMatchBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}