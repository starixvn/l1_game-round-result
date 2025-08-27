using System;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("SeDieTicketViewModel")]
    public class SeDieMultiplayerTicketViewModel : GameTicketViewModel
    {
        public SeDieMultiplayerRoundResultViewModel RoundResult { get; set; }

        public SeDieMultiplayerBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Odd + Bet.Even + Bet.ThreeRed + Bet.FourRed + Bet.ThreeWhite + Bet.FourWhite + Bet.TwoRed;

        public decimal TotalWin => Bet.BetWin;

        public decimal WinLoss => Bet.FreeBet ? TotalWin : TotalWin - TotalBet;
    }

    public class SeDieMultiplayerBetViewModel : SeDieBetViewModel { }
}
