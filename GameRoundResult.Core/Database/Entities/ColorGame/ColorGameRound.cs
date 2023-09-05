using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities.ColorGame
{
    [CollectionName("colorgame_rounds")]
    public class ColorGameRound : GameRound
    {
        public ColorGameResult Result { get; set; }

        public ColorGameSettlementResult SettlementResult { get; set; }
    }

    public class ColorGameResult
    {
        [BsonElement("dice1")]
        public byte Dice1 { get; set; }

        [BsonElement("dice2")]
        public byte Dice2 { get; set; }

        [BsonElement("dice3")]
        public byte Dice3 { get; set; }
    }

    public class ColorGameSettlementResult
    {
        public bool Yellow { get; set; }

        public bool Red { get; set; }

        public bool Pink { get; set; }

        public bool White { get; set; }

        public bool Blue { get; set; }

        public bool Green { get; set; }

        public bool Hot { get; set; }

        public bool Cold { get; set; }
    }    
}
