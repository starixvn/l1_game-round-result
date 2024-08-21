using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sedie3_rounds")]
    public class SeDie3Round : GameRound
    {
        public SeDie3ResultEntity Result { get; set; }

        public SeDie3SettlementResultEntity SettlementResult { get; set; }
    }

    public class SeDie3ResultEntity
    {
        [BsonElement("red1")]
        public bool FirstRedChip { get; set; }

        [BsonElement("red2")]
        public bool SecondRedChip { get; set; }

        [BsonElement("red3")]
        public bool ThirdRedChip { get; set; }
    }

    public class SeDie3SettlementResultEntity
    {
        public bool Red { get; set; }

        public bool White { get; set; }

        [BsonElement("red1")]
        public bool OneRed { get; set; }

        [BsonElement("red2")]
        public bool TwoRed { get; set; }

        [BsonElement("red3")]
        public bool ThreeRed { get; set; }

        [BsonElement("white3")]
        public bool ThreeWhite { get; set; }
    }
}
