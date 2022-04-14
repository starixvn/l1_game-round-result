using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class TreasureIslandTicketViewModel : GameTicketViewModel
    {
        public TreasureIslandRoundResultViewModel RoundResult { get; set; }

        public decimal BetWin => RoundResult.BetWin;

        public decimal WinLoss => BetWin - RoundResult.TotalAmount;
    }

    public class TreasureIslandRoundResultViewModel : RoundResultViewModel
    {
        public decimal BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal BetWin { get; set; }

        public List<byte[]> Boards { get; set; }

        public List<double> TumbleWins { get; set; }

        public List<int> TumbleMultipliers { get; set; }

        public List<Dictionary<int, double>> WinningIcons { get; set; }

        public List<Dictionary<int, double>> WinningAmounts { get; set; }
    }
}