using System;

namespace GameRoundResult.Web.Models
{
    public class DragonTigerFightTicketViewModel : GameTicketViewModel
    {
        public DragonTigerFightRoundResultViewModel RoundResult { get; set; }

        public DragonTigerFightBetViewModel Bet { get; set; }

        public new decimal TotalBet => Bet.Dragon + Bet.Tiger + Bet.Tie + Bet.BlackDragon + Bet.RedDragon + Bet.BlackTiger + Bet.RedTiger;

        public decimal TotalWin => Bet.BetWin ;

        public new decimal WinLoss => TotalWin - TotalBet;
    }

    public class DragonTigerFightBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }

        public decimal BlackDragon { get; set; }

        public decimal RedDragon { get; set; }

        public decimal BlackTiger { get; set; }

        public decimal RedTiger { get; set; }

        public decimal BetWin { get; set; }
    }
}