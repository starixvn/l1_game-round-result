using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaseBetEntity : Document
    {
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public long RoundId { get; set; }

        public string PlayerId { get; set; }

        public string SiteId { get; set; }

        [BsonDefaultValue(false)]
        public bool? FreeBet { get; set; }

        public string Currency { get; set; }

        public string OperatorId { get; set; }

        public decimal Rate { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }
}