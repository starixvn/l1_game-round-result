using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Models
{
    public class BigSmallTicketViewModel
    {
        public BigSmallRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BigSmallBetViewModel> Bets { get; set; }

        public decimal TotalBet => Bets.Sum(x => x.Bet);

        public decimal TotalBack => Bets.Sum(x => x.Back);

        public decimal TotalBetWin => Bets.Sum(x => x.BetWin);

        public decimal TotalWin => TotalBetWin > 0 ? TotalBet + TotalBetWin : 0;

        public decimal WinLoss => TotalWin + TotalBack - TotalBet;
    }

    public class BigSmallBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal BetWin { get; set; }

        public decimal Back { get; set; }

        public bool Select { get; set; }

        public decimal Bet { get; set; }
    }
}
