using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class BlackjackTicketViewModel : GameTicketViewModel
    {
        public BlackjackBetViewModel Bet { get; set; }

        public IEnumerable<CardViewModel> DealerCards { get; set; }

        public byte DealerPoint { get; set; }

        public bool Ended { get; set; }

        public decimal WinLoss => Bet.BetWin - Bet.Bet;
    }

    public class BlackjackBetViewModel
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

    public class CardViewModel
    {
        public string Rank { get; set; }

        public byte Suit { get; set; }
    }
}