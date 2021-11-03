using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("taixiu_phiens")]
    public class BigSmallRound : GameRound
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }

        public BigSmallResult Result { get; set; }
    }

    [CollectionName("txturbo_phiens")]
    public class TurboBigSmallRound : BigSmallRound
    {

    }

    public class BigSmallResult
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }
    }
}