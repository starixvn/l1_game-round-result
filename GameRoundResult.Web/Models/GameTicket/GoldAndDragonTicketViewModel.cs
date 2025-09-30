using GameRoundResult.Core.Database.Entities.CoinMining;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models.GameTicket
{
    [TolgeeNamespace("GoldAndDragon")]
    public class GoldAndDragonTicketViewModel : GameTicketViewModel
    {
        public GoldAndDragonRound Bet { get; set; }

        public new decimal WinLoss => Bet?.BetWin - Bet?.Amount ?? 0;

        public bool HasSymbolData { get; set; }

        public IEnumerable<SymbolsInfo> GetWinningSymbols()
        {
            return Bet?.SettlementResult?.Tumbles?
                .SelectMany(t => t.Symbols ?? Enumerable.Empty<SymbolsInfo>())
                .Where(s => s.Win > 0) ?? Enumerable.Empty<SymbolsInfo>();
        }

        public int TotalWinningSymbolsCount => GetWinningSymbols().Sum(s => s.Count);

        public BaseCascadingClusterTumble GetInitialSpin()
        {
            return Bet?.SettlementResult?.Tumbles?.FirstOrDefault();
        }

        public IEnumerable<BaseCascadingClusterTumble> GetTumbles()
        {
            return Bet?.SettlementResult?.Tumbles ?? Enumerable.Empty<BaseCascadingClusterTumble>();
        }

        public bool HasMultipleTumbles => GetTumbles().Count() > 1;

        public decimal TotalTumbleWin => GetTumbles().Sum(t => t.Win);

        public string GetRoundIdDisplay()
        {
            var roundId = Bet?.RoundId.ToString() ?? "";
            
            if (Bet?.BuyFreeSpin == true)
            {
                return $"{roundId} (Buy Feature)";
            }
            
            if (Bet?.FreeSpin == true)
            {
                return $"{roundId} (Free Spin 1/10)"; // TODO: Get actual free spin count
            }
            
            return roundId;
        }
    }
}
