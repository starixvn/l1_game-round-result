using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    public class CrashGameBetLogViewModel : BetLogViewModel
    {
        public decimal WinAmount { get; set; }
        public decimal Multiplier { get; set; }
        public string Action { get; set; }
        public bool ReachMaxWin { get; set; }

        public string DisplayWinAmount => Action == CrashGameAction.Bet ? string.Empty : WinAmount.Format();
        public string DisplayMultiplier => Multiplier > 0 ? $"{Multiplier}x" : "-";
    }
}
