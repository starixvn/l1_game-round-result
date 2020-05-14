using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public abstract class GameRound : Document
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Time { get; set; }

        [BsonElement("id")]
        public long Round { get; set; }
    }
}