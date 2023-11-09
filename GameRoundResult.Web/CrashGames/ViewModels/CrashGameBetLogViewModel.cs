using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    public class CrashGameBetLogViewModel : BetLogViewModel
    {
        public decimal WinAmount { get; set; }
        public decimal Multiplier { get; set; }
        public string Action { get; set; }
    }
}
