using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.SevenUpDown
{
    [CollectionName("sevenupdown_bets")]
    public class SevenUpDownBet : RoundHistoryBetEntity
    {
        public decimal Up { get; set; }

        public decimal Down { get; set; }

        public decimal Seven { get; set; }

        public bool ReachMaxWin { get; set; }
    }
}
