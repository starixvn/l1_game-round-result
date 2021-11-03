using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("baucua_phiens")]
    public class FishPrawnCrabRound : GameRound
    {
        public FishPrawnCrabResult Result { get; set; }
    }

    public class FishPrawnCrabResult
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }
    }
}