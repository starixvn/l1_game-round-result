using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("minisedie_phiens")]
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

        public MiniSeDieResult Result { get; set; }

        public MiniSeDieSettlementResultEntity SettlementResult { get; set; }
    }

    [CollectionName("minisedie2_rounds")]
    public class MiniSeDie2Round : MiniSeDieRound
    {
    }

    [CollectionName("minisedie3_rounds")]
    public class MiniSeDie3Round : MiniSeDieRound
    {
    }

    [CollectionName("minisedie4_rounds")]
    public class MiniSeDie4Round : MiniSeDieRound
    {
    }

    public class MiniSeDieResult
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

    public class MiniSeDieSettlementResultEntity
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        [BsonElement("red3")]
        public bool ThreeRed { get; set; }

        [BsonElement("red4")]
        public bool FourRed { get; set; }

        [BsonElement("white3")]
        public bool ThreeWhite { get; set; }

        [BsonElement("white4")]
        public bool FourWhite { get; set; }
    }
}