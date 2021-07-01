using System;

namespace GameRoundResult.Web.Models
{
    public class VipSeDieTicketViewModel : GameTicketViewModel
    {
        public VipSeDieRoundResultViewModel RoundResult { get; set; }

        public VipSeDieBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Odd + Bet.Even + Bet.TwoRed + Bet.ThreeRed + Bet.FourRed + Bet.ThreeWhite + Bet.FourWhite;

        public decimal WinLoss => Bet.BetWin - TotalBet;
    }

    public class VipSeDieBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal TwoRed { get; set; }

        public decimal ThreeRed { get; set; }

        public decimal FourRed { get; set; }

        public decimal ThreeWhite { get; set; }

        public decimal FourWhite { get; set; }

        public decimal BetWin { get; set; }
    }
}