using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("chanle_phiens")]
    public class OddEvenRound : GameRound
    {
        public OddEvenResult Result { get; set; }
    }

    [CollectionName("chanleturbo_phiens")]
    public class TurboOddEvenRound : OddEvenRound
    {

    }

    public class OddEvenResult
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }
    }
}