using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaseBetEntity : Document
    {
        [BsonElement("thanhtoan")]
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        [BsonElement("phien")]
        public long Round { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }

        [BsonDefaultValue(false)]
        public bool? FreeBet { get; set; }
    }
}