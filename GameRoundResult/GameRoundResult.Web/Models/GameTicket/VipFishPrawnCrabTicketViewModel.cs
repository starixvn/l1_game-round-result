using System;

namespace GameRoundResult.Web.Models.GameTicket
{
    public class VipFishPrawnCrabTicketViewModel : GameTicketViewModel
    {
        public VipFishPrawnCrabRoundResultViewModel RoundResult { get; set; }

        public VipFishPrawnCrabBetViewModel Bet { get; set; }

        public decimal TotalBet => Bet.Stag + Bet.Gourd + Bet.Rooster + Bet.Fish + Bet.Crab + Bet.Prawn + Bet.AnyTriple;

        public decimal TotalWin =>  Bet.BetWin;

        public decimal WinLoss => TotalWin - TotalBet;
    }

    public class VipFishPrawnCrabBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal BetWin { get; set; }

        public decimal Stag { get; set; }

        public decimal Gourd { get; set; }

        public decimal Rooster { get; set; }

        public decimal Fish { get; set; }

        public decimal Crab { get; set; }

        public decimal Prawn { get; set; }

        public decimal AnyTriple { get; set; }

        public decimal Mountain { get; set; }

        public decimal Ocean { get; set; }
    }
}