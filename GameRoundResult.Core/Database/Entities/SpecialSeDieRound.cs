using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class SpecialSeDieRound : GameRound
    {
        public SpecialSeDieResultEntity Result { get; set; }

        public SpecialSeDieSettlementResultEntity SettlementResult { get; set; }
    }

    public class SpecialSeDieResultEntity
    {
        [BsonElement("red1")]
        public bool FirstRedChip { get; set; }

        [BsonElement("red2")]
        public bool SecondRedChip { get; set; }

        [BsonElement("red3")]
        public bool ThirdRedChip { get; set; }

        [BsonElement("red4")]
        public bool FourthRedChip { get; set; }
    }

    public class SpecialSeDieSettlementResultEntity
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }
    }
}