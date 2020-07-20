using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class BigSmallBet : BaseBetEntity
    {
        [BsonElement("taixiu")]
        public bool BigSmall { get; set; }

        [BsonElement("tralai")]
        public decimal Back { get; set; }

        public decimal Bet { get; set; }

        public bool Select { get; set; }
    }
}