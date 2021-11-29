using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaseBetLogEntity : Document
    {
        public string Uid { get; set; }

        public string Name { get; set; }

        [BsonElement("phien")]
        public long Round { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }
    }
}