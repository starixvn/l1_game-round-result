using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sicbo_phiens")]
    public class SicBoRound : GameRound
    {
        public SicBoResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class SicBoResult
    {
        [BsonElement("dice1")]
        public byte FirstDice { get; set; }

        [BsonElement("dice2")]
        public byte SecondDice { get; set; }

        [BsonElement("dice3")]
        public byte ThirdDice { get; set; }
    }
}