using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class MiniSeDieRound : GameRound
    {
        [BsonElement("red1")]
        public bool FirstRedChip { get; set; }

        [BsonElement("red2")]
        public bool SecondRedChip { get; set; }

        [BsonElement("red3")]
        public bool ThirdRedChip { get; set; }

        [BsonElement("red4")]
        public bool FourthRedChip { get; set; }

        public MiniSeDieSettlementResult SettlementResult { get; set; }
    }

    public class MiniSeDieSettlementResult
    {
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Red3 { get; set; }
        public bool Red4 { get; set; }
        public bool White3 { get; set; }
        public bool White4 { get; set; }
    }
}