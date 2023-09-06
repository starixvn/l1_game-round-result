using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.ColorGame
{
    [CollectionName("colorgame_rounds")]
    public class ColorGameRound : GameRound
    {
        public ColorGameResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }
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
}
