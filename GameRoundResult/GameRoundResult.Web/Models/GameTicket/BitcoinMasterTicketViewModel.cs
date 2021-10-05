using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BitcoinMasterTicketViewModel : GameTicketViewModel
    {
        public BitcoinMasterRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BitcoinMasterBetViewModel> Bets { get; set; }

        public decimal TotalBet => Bets.Sum(x => x.Bet);

        public decimal TotalRefund => Bets.Sum(x => x.Refund);

        public decimal TotalBetWin => Bets.Sum(x => x.BetWin);

        public decimal TotalWin => TotalBetWin > 0 ? TotalBet + TotalBetWin - TotalRefund : 0;

        public decimal WinLoss => TotalWin + TotalRefund - TotalBet;
    }

    public class BitcoinMasterBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Bet { get; set; }

        public decimal BetWin { get; set; }

        public decimal Refund { get; set; }

        public string Choice { get; set; }
    }
}