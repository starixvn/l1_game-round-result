using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class BlackjackTicketViewModel : GameTicketViewModel
    {
        public BlackjackBetViewModel Bet { get; set; }

        public IEnumerable<BlackjackCardViewModel> DealerCards { get; set; }

        public byte DealerPoint { get; set; }

        public bool End { get; set; }

        public decimal WinLoss => Bet.BetWin - Bet.Bet;
    }

    public class BlackjackBetViewModel
    {
        public DateTime Time { get; set; }

        public long HandId { get; set; }

        public IEnumerable<BlackjackCardViewModel> Cards { get; set; }

        public byte Total { get; set; }

        public byte? SplitFrom { get; set; }

        public decimal Bet { get; set; }

        public decimal BetWin { get; set; }
    }

    public class BlackjackCardViewModel
    {
        public string Rank { get; set; }

        public byte Suit { get; set; }
    }
}