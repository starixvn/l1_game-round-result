using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratXRound : BaseBaccaratRoundEntity
    {
        public BaccaratXResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }

        public IEnumerable<BaccaratXMultiplierCard> OddsMultipliers { get; set; }

        public AppliedMultipliers AppliedMultipliers { get; set; }

        public decimal ExtraFeeRatio { get; set; }
    }

    public class BaccaratXResult
    {
        public BaccaratXCardResult Player { get; set; }

        public BaccaratXCardResult Banker { get; set; }
    }

    public class BaccaratXCardResult : BaccaratCardResult
    {
        public byte Score { get; set; }
    }

    public class AppliedMultipliers
    {
        public IEnumerable<BaccaratXMultiplierCard> Player { get; set; } = Enumerable.Empty<BaccaratXMultiplierCard>();
        public IEnumerable<BaccaratXMultiplierCard> Banker { get; set; } = Enumerable.Empty<BaccaratXMultiplierCard>();
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