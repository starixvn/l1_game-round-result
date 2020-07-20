using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class RNGKenoTicketViewModel : GameTicketViewModel
    {
        public KenoRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<RNGKEnoBetViewModel> Bets { get; set; }

        public decimal TotalBet => Bets.Sum(x => x.Amount);

        public decimal TotalWin { get; set; }

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class RNGKEnoBetViewModel
    {
        public DateTime Time { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}