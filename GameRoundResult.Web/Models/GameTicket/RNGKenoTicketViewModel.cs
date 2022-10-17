using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class RNGKenoTicketViewModel : GameTicketViewModel
    {
        public KenoRoundResultViewModel RoundResult { get; set; }

        public RNGKenoBetViewModel Bet { get; set; }

        public decimal WinLoss => Bet.Betwin - Bet.TotalAmount;
    }

    public class RNGKenoBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Betwin { get; set; }

        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal Gold { get; set; }

        public decimal Earth { get; set; }

        public decimal Fire { get; set; }

        public decimal Water { get; set; }

        public decimal Wood { get; set; }

        public decimal TotalAmount { get; set; }
    }
}