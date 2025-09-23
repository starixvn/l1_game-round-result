using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("baccaratmultiplayer_rounds")]
    public class BaccaratMultiplayerRound : BaseBaccaratRoundEntity
    {
        public BaccaratResult Result { get; set; }

        public BaccaratMultiplayerSettlementResult SettlementResult { get; set; }
    }

    public class BaccaratMultiplayerSettlementResult
    {
        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Tie { get; set; }
        public bool AnyPair { get; set; }
    }
}