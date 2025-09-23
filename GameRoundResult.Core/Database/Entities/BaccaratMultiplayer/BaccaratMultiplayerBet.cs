using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("baccaratmultiplayer_bets")]
    public class BaccaratMultiplayerBet : RoundHistoryBetEntity
    {
        public decimal Banker { get; set; }

        public decimal Player { get; set; }

        public decimal AnyPair { get; set; }

        public decimal Tie { get; set; }
    }
}