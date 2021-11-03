using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("specialsedie_cuocs")]
    public class SpecialSeDieBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }

        [BsonElement("thanhtoan")]
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }
    }
}