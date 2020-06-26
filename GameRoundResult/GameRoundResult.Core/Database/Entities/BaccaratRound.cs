using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratRound : GameRound
    {
        public Side Player { get; set; }

        public Side Banker { get; set; }

        public BaccaratResult Result { get; set; }
    }

    public class BaccaratResult
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
        public Card FirstCard { get; set; }

        [BsonElement("card2")]
        public Card SecondCard { get; set; }

        [BsonElement("card3")]
        public Card ThirdCard { get; set; }
    }
}