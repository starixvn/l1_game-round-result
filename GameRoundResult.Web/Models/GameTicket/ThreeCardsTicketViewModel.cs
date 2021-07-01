using System;

namespace GameRoundResult.Web.Models
{
    public class ThreeCardsTicketViewModel : GameTicketViewModel
    {
        public ThreeCardsBetViewModel Bet { get; set; }

        public ThreeCardsRoundResultViewModel RoundResult { get; set; }

        public decimal TotalBet => Bet.Red + Bet.Black + Bet.Diamonds + Bet.Hearts + Bet.Spades + Bet.Clubs;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class ThreeCardsBetViewModel
    {
        public DateTime Time { get; set; }

        public ThreeCardsOddsViewModel Odds { get; set; }

        public decimal Red { get; set; }
        public decimal Black { get; set; }
        public decimal Diamonds { get; set; }
        public decimal Hearts { get; set; }
        public decimal Spades { get; set; }
        public decimal Clubs { get; set; }

        public decimal BetWin { get; set; }
    }

    public class ThreeCardsOddsViewModel
    {
        public decimal Red { get; set; }
        public decimal Black { get; set; }
        public decimal Diamonds { get; set; }
        public decimal Hearts { get; set; }
        public decimal Spades { get; set; }
        public decimal Clubs { get; set; }
    }
}