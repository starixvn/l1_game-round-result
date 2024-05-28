using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratXBet : BaseBetEntity
    {
        public decimal Banker { get; set; }

        public decimal BankerPair { get; set; }

        public decimal Player { get; set; }

        public decimal PlayerPair { get; set; }

        public decimal Tie { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Fee { get; set; }

        public Dictionary<string, IEnumerable<byte>> Multipliers { get; set; }
    }

    [CollectionName("bac81_bets")]
    public class Bac81Bet : BaccaratXBet
    {
    }
}