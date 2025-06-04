using System.Collections.Generic;
using System;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SoloBlackjack")]
    public class SoloBlackjackTicketViewModel : GameTicketViewModel
    {
        public SoloBlackjackBetViewModel Bet { get; set; }

        public IEnumerable<CardViewModel> DealerCards { get; set; }

        public byte DealerPoint { get; set; }

        public bool Ended { get; set; }

        public decimal WinLoss => Bet.BetWin - Bet.Bet;
    }

    public class SoloBlackjackBetViewModel
    {
        public DateTime Time { get; set; }

        public long HandId { get; set; }

        public IEnumerable<CardViewModel> Cards { get; set; }

        public IEnumerable<string> Actions { get; set; }

        public IEnumerable<byte> SoftPoints { get; set; }

        public byte Total { get; set; }

        public long? SplitFrom { get; set; }

        public decimal Bet { get; set; }

        public decimal BetWin { get; set; }
    }
}
