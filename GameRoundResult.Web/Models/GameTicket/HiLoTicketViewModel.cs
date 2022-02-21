using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class HiLoTicketViewModel : GameTicketViewModel
    {
        public HiLoRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<HiLoBetLogViewModel> BetLogs { get; set; }

        public decimal WinLoss => RoundResult.Betwin - RoundResult.Amount;

    }

    public class HiLoBetLogViewModel
    {
        public DateTime Time { get; set; }

        public int Order { get; set; }

        public decimal Amount { get; set; }

        public string Choice { get; set; }

        public decimal Betwin { get; set; }

        public IEnumerable<CardViewModel> Cards { get; set; }
    }

}