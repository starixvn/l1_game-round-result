using System;

namespace GameRoundResult.Web.Models
{
    public class SeDieTicketViewModel : GameTicketViewModel
    {
        public SeDieRoundResultViewModel RoundResult { get; set; }

        public SeDieBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Odd + Bet.Even + Bet.ThreeRed + Bet.FourRed + Bet.ThreeWhite + Bet.FourWhite;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class SeDieBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal ThreeRed { get; set; }

        public decimal FourRed { get; set; }

        public decimal ThreeWhite { get; set; }

        public decimal FourWhite { get; set; }

        public decimal BetWin { get; set; }
    }
}