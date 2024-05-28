using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("baccarat_phiens")]
    public class BaccaratRound : BaseBaccaratRoundEntity
    {
        public Side Player { get; set; }

        public Side Banker { get; set; }

        public BaccaratSettlementResult Result { get; set; }
    }

    public class BaseBaccaratRoundEntity : GameRound
    {
    }

    public class BaccaratSettlementResult
    {
        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Tie { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool PlayerPair { get; set; }
        public bool BankerPair { get; set; }
        public bool Natural { get; set; }
    }

    public class Side
    {
        [BsonElement("card1")]
        public DragonTigerCard FirstCard { get; set; }

        [BsonElement("card2")]
        public DragonTigerCard SecondCard { get; set; }

        [BsonElement("card3")]
        public DragonTigerCard ThirdCard { get; set; }
    }
}