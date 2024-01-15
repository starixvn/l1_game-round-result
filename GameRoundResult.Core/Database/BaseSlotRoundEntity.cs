using System;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database
{
    public class BaseSlotRoundEntity : GameRound
    {
        public string SiteId { get; set; }

        public string PlayerId { get; set; }

        public string OperatorId { get; set; }

        public bool Paid { get; set; }

        public decimal TotalAmount { get; set; }

        public bool FreeSpin { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }
    }
}