using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.SevenUpDown
{
    [CollectionName("sevenupdown_rounds")]
    public class SevenUpDownRound : GameRound
    {
        public SevenUpDownResultEntity Result { get; set; }

        public SevenUpDownSettlementResultEntity SettlementResult { get; set; }
    }

    public class SevenUpDownResultEntity
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        public MultiplierEntity Multiplier { get; set; }
    }

    public class MultiplierEntity
    {
        public int Value { get; set; }
        public string Choice { get; set; }
    }

    public class SevenUpDownSettlementResultEntity
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Seven { get; set; }
    }
}
