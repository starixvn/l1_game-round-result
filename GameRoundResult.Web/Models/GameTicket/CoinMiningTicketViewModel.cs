using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Core.Database.Entities.CoinMining;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models.GameTicket
{
    [TolgeeNamespace("CoinMining")]
    public class CoinMiningTicketViewModel : GameTicketViewModel
    {
        public IEnumerable<CoinMiningBetLogViewModel> BetLogs { get; set; }
        public CoinMiningBet Bet { get; set; }
        public DateTime Time { get; set; }

        public decimal WinLoss => Bet.Betwin - Bet.Amount;

        public string GetResult() => Bet.Betwin > 0 ? "cash_out" : "crashed";

        public string GetMultiplier() => Bet.Multiplier > 0 ? $"{Bet.Multiplier.ToString("N2", CultureInfo.InvariantCulture)}x" : "-";
        public string FormatNumber(decimal number) => number % 1 == 0
            ? number.ToString("N0", CultureInfo.InvariantCulture)
            : number.ToString("0.##", CultureInfo.InvariantCulture);
        public string GetCrashPoint() => $"{Bet.Result.ToString("N2", CultureInfo.InvariantCulture)}x";
        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";
        public string CashOutClassName => WinLoss < 0 ? "" : "bet-win-text";

    }

    public class CoinMiningBetLogViewModel : BetLogViewModel
    {
        
    }
}
