using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class Win3CardsTicketViewModel : GameTicketViewModel
    {
        public Win3CardsRoundResultViewModel RoundResult { get; set; }

        public Win3CardsBetViewModel Bet { get; set; }

        public decimal WinLoss => Bet.Betwin - Bet.TotalAmount;
    }

    public class Win3CardsBetViewModel
    {
        public Dictionary<string, decimal> Odds { get; set; }

        public decimal Dragon { get; set; }

        public decimal Phoenix { get; set; }

        public decimal Pair8Plus { get; set; }

        public decimal Straight { get; set; }

        public decimal FLush { get; set; }

        public decimal StraightFlush { get; set; }

        public decimal ThreeKind { get; set; }

        public decimal Betwin { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
