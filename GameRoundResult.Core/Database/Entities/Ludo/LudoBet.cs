using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.Ludo
{
    [CollectionName("ludo_bets")]
    public class LudoBet : RoundHistoryBetEntity
    {
        public decimal BetWin { get; set; }
        public bool ReachMaxWin { get; set; }

        public decimal Odd { get; set; }
        public decimal Even { get; set; }
        public decimal Big { get; set; }
        public decimal Small { get; set; }
        public decimal Kick { get; set; }
        public decimal NoKick { get; set; }
        public decimal Move { get; set; }
        public decimal NoMove { get; set; }
        public decimal Release { get; set; }
        public decimal NoRelease { get; set; }
        public decimal GoStable { get; set; }
        public decimal NoStable { get; set; }
    }
}
