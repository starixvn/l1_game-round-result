using System.Collections.Generic;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratXBet : RoundHistoryBetEntity
    {
        public decimal Banker { get; set; }

        public decimal BankerPair { get; set; }

        public decimal Player { get; set; }

        public decimal PlayerPair { get; set; }

        public decimal Tie { get; set; }

        public decimal Fee { get; set; }

        public Dictionary<string, IEnumerable<byte>> Multipliers { get; set; }
    }

    [CollectionName("bac81_bets")]
    public class Bac81Bet : BaccaratXBet
    {
    }
}