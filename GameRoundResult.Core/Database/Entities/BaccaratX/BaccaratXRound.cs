using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratXRound : BaseBaccaratRoundEntity
    {
        public BaccaratResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }

        public IEnumerable<BaccaratXMultiplierCard> OddsMultipliers { get; set; }

        public IEnumerable<BaccaratXMultiplierCard> AppliedMultipliers { get; set; }

        public decimal ExtraFeeRatio { get; set; }
    }

    public class BaccaratXSettlementResult
    {
        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Tie { get; set; }
        public bool PlayerPair { get; set; }
        public bool BankerPair { get; set; }
    }

    public class BaccaratXMultiplierCard : BaccaratCard
    {
        public byte Value { get; set; }
    }

    [CollectionName("bac81_rounds")]
    public class Bac81Round : BaccaratXRound
    {
    }
}