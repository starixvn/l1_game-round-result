using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class DragonTigerRound : GameRound
    {
        public DragonTigerResult Result { get; set; }
        public Card Dragon { get; set; }

        public Card Tiger { get; set; }
    }

    public class DragonTigerResult
    {
        public Card Dragon { get; set; }

        public Card Tiger { get; set; }
    }

    public class Card
    {
        [BsonElement("card")]
        public byte Number { get; set; }

        public byte Type { get; set; }
    }
}