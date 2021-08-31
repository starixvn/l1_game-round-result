using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class KenoPowerTicketViewModel : GameTicketViewModel
    {
        public KenoPowerRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<KenoPowerBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;

        public Dictionary<string, decimal> Odds { get; set; }
    }

    public class KenoPowerBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}