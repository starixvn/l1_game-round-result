using System.Collections.Generic;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    public class CrashGameTicketViewModel : GameTicketViewModel
    {
        public CrashGameRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<CrashGameBetLogViewModel> BetLogs { get; set; }
    }
}