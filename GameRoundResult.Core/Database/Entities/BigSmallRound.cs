using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{

    [CollectionName(roundCollectionName:"taixiu_phiens", betCollectionName: "taixiu_cuocs")]
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