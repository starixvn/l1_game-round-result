using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaseCrashTurnBetEntity : Document
    {
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        [BsonElement("id")]
        public long RoundId { get; set; }

        public string PlayerId { get; set; }

        public string SiteId { get; set; }

        [BsonDefaultValue(false)]
        public bool? FreeBet { get; set; }

        public string Currency { get; set; }

        public string OperatorId { get; set; }

        public decimal Rate { get; set; }
        public decimal Multiplier { get; set; }
        public decimal Result { get; set; }
        public long TapCount { get; set; }

        public bool? ReachMaxWin { get; set; }
    }
}
