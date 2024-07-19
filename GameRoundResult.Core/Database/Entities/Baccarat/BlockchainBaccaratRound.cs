using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("blockchainbaccarat_rounds")]
    public class BlockchainBaccaratRound : BaseBaccaratRoundEntity
    {
        public BaccaratResult Result { get; set; }

        public BaccaratSettlementResult SettlementResult { get; set; }
    }

    public class BaccaratResult
    {
        public BaccaratCardResult Player { get; set; }

        public BaccaratCardResult Banker { get; set; }
    }

    public class BaccaratCardResult
    {
        [BsonElement("card1")]
        public BaccaratCard FirstCard { get; set; }

        [BsonElement("card2")]
        public BaccaratCard SecondCard { get; set; }

        [BsonElement("card3")]
        public BaccaratCard ThirdCard { get; set; }
    }

    public class BaccaratCard
    {
        [BsonElement("rank")]
        public byte Number { get; set; }

        [BsonElement("suit")]
        public byte Type { get; set; }
    }

}
