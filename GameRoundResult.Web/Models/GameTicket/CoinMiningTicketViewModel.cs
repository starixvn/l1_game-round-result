using System;
using System.Collections.Generic;
using GameRoundResult.Core.Database.Entities.CoinMining;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models.GameTicket
{
    [TolgeeNamespace("CoinMining")]
    public class CoinMiningTicketViewModel : GameTicketViewModel
    {
        public IEnumerable<CoinMiningBetLogViewModel> BetLogs { get; set; }
        public CoinMiningBet Bet { get; set; }

        public decimal WinLoss => Bet.Betwin - Bet.Amount;

        public string GetResult() => Bet.Betwin > 0 ? "cash_out" : "Crashed";

        public string GetMultiplier() => Bet.Multiplier > 0 ? string.Format("{0:0.##}x", Bet.Multiplier) : "-";

    }

    public class CoinMiningBetLogViewModel : BetLogViewModel
    {
        
    }
}
