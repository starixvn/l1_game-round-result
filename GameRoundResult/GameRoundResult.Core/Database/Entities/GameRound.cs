using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class GameRound : Document
    {
        [BsonElement("id")]
        public long Round { get; set; }
    }
}