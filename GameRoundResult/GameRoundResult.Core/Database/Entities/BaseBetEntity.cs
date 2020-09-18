using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaseBetEntity : Document
    {
        [BsonElement("thanhtoan")]
        public bool Paid { get; set; }

        public decimal Betwin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        [BsonElement("phien")]
        public long Round { get; set; }

        public bool Red { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }
    }
}