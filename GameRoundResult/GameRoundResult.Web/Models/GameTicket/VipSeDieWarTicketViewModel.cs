using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieWarTicketViewModel : GameTicketViewModel
    {
        public VipSeDieWarRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<VipSeDieWarBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;
    }

    public class VipSeDieWarBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}