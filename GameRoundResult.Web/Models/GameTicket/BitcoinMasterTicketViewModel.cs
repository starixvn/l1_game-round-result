using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class BitcoinMasterTicketViewModel : GameTicketViewModel
    {
        public BitcoinMasterRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BitcoinMasterBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalRefund { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin + TotalRefund - TotalBet;
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