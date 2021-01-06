using System;

namespace GameRoundResult.Web.Models
{
    public class MiniSeDieTicketViewModel : GameTicketViewModel
    {
        public MiniSeDieRoundResultViewModel RoundResult { get; set; }

        public MiniSeDieBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Odd + Bet.Even + Bet.ThreeRed + Bet.FourRed + Bet.ThreeWhite + Bet.FourWhite;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => Bet.FreeBet ? TotalWin : TotalWin - TotalBet;
    }

    public class MiniSeDieBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal ThreeRed { get; set; }

        public decimal FourRed { get; set; }

        public decimal ThreeWhite { get; set; }

        public decimal FourWhite { get; set; }

        public decimal BetWin { get; set; }

        public bool FreeBet { get; set; }
    }
}