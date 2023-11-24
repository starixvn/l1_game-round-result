using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashGames.ViewModels
{
    [TolgeeNamespace("Spaceflight")]
    public class CrashGameTicketViewModel : GameTicketViewModel
    {
        public CrashGameRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<CrashGameBetLogViewModel> BetLogs { get; set; }

        public bool HasHalfCashOut => BetLogs.Any(x => x.Action == CrashGameAction.HalfCashOut);
        public bool HasCashOut => BetLogs.Any(x => x.Action == CrashGameAction.CashOut);
        public bool HasRefund => BetLogs.Any(x => x.Action == CrashGameAction.Refund);
        public bool ReachMaxWin => BetLogs.Any(x => x.ReachMaxWin);
    }
}