using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("karakrus_bets")]
    public class KaraKrusBet : RoundHistoryBetEntity
    {
        public decimal Kara { get; set; }

        public decimal Krus { get; set; }

        [BsonElement("head1")]
        public decimal OneHead { get; set; }

        [BsonElement("head2")]
        public decimal TwoHead { get; set; }

        [BsonElement("head3")]
        public decimal ThreeHead { get; set; }

        [BsonElement("tail3")]
        public decimal ThreeTail { get; set; }
    }
}
