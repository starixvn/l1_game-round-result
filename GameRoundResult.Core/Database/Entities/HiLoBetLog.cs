using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("hilo_betlogs")]
    public class HiLoBetLog : BaseBetLogEntity
    {
        public long RoundId { get; set; }

        public int Order { get; set; }

        public decimal Amount { get; set; }

        public string Choice { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}