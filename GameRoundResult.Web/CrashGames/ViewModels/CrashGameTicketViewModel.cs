using System.Collections.Generic;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    [TolgeeNamespace("Spaceflight")]
    public class CrashGameTicketViewModel : GameTicketViewModel
    {
        public CrashGameRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<CrashGameBetLogViewModel> BetLogs { get; set; }
    }
}