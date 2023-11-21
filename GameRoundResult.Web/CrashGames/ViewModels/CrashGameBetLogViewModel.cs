using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    public class CrashGameBetLogViewModel : BetLogViewModel
    {
        public decimal WinAmount { get; set; }
        public decimal Multiplier { get; set; }
        public string Action { get; set; }

        public string DisplayWinAmount => WinAmount.Format();
        public string DisplayMultiplier => Multiplier > 0 ? $"{Multiplier}x" : "-";
    }
}
