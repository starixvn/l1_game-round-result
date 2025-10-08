using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CrashTurnGames.ViewModels
{
    [TolgeeNamespace("CoinMining")]
    public class CrashTurnGameTicketViewModel : GameTicketViewModel
    {
        public IEnumerable<CrashTurnBetLogViewModel> BetLogs { get; set; }
        public BaseCrashTurnRoundEntity Bet { get; set; }
        public DateTime Time { get; set; }

        public new decimal WinLoss => Bet.Betwin - Bet.Amount;

        public string GetResult() => Bet.Betwin > 0 ? "cash_out" : "crashed";

        public string GetMultiplier() => Bet.Multiplier > 0 ? $"{Bet.Multiplier.ToString("N2", CultureInfo.InvariantCulture)}x" : "-";
        public string FormatNumber(decimal number) => number % 1 == 0
            ? number.ToString("N0", CultureInfo.InvariantCulture)
            : number.ToString("0.##", CultureInfo.InvariantCulture);
        public string GetCrashPoint() => $"{Bet.Result.ToString("N2", CultureInfo.InvariantCulture)}x";

        public bool IsReachMaxWin() => Bet.ReachMaxWin ?? false;
        public DateTime GetBetTime() => Bet.Time.AddHours(TimeZoneOffset.TotalHours);
        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";
        public string CashOutClassName => WinLoss < 0 ? "" : "bet-win-text";

    }

    public class CrashTurnBetLogViewModel : BetLogViewModel
    {
        
    }
}
