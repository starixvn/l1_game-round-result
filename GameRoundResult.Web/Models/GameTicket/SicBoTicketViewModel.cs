using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class SicBoTicketViewModel : GameTicketViewModel
    {
        public SicBoRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<SicBoBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;
    }

    public class SicBoBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}