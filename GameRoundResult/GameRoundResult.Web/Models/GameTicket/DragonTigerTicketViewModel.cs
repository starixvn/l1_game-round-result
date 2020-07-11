using System;

namespace GameRoundResult.Web.Models.GameTicket
{
    public class DragonTigerTicketViewModel : GameTicketViewModel
    {
        public DragonTigerRoundResultViewModel RoundResult { get; set; }

        public DragonTigerBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Dragon + Bet.Tiger + Bet.Tie;

        public decimal TotalWin => Bet.BetWin > 0 ? TotalBet + Bet.BetWin : 0;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class DragonTigerBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }

        public decimal BetWin { get; set; }
    }
}