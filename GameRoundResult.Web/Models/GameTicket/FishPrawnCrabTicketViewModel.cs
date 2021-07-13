using System;

namespace GameRoundResult.Web.Models
{
    public class FishPrawnCrabTicketViewModel : GameTicketViewModel
    {
        public FishPrawnCrabRoundResultViewModel RoundResult { get; set; }

        public FishPrawnCrabBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Stag + Bet.Gourd + Bet.Rooster + Bet.Fish + Bet.Crab + Bet.Prawn;

        public decimal TotalWin =>  Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class FishPrawnCrabBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal BetWin { get; set; }

        public decimal Stag { get; set; }

        public decimal Gourd { get; set; }

        public decimal Rooster { get; set; }

        public decimal Fish { get; set; }

        public decimal Crab { get; set; }

        public decimal Prawn { get; set; }
    }
}