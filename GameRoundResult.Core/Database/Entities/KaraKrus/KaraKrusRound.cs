using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("karakrus_rounds")]
    public class KaraKrusRound : GameRound
    {
        public KaraKrusResultEntity Result { get; set; }

        public KaraKrusSettlementResultEntity SettlementResult { get; set; }
    }

    public class KaraKrusResultEntity
    {
        [BsonElement("head1")]
        public bool FirstHeadChip { get; set; }

        [BsonElement("head2")]
        public bool SecondHeadChip { get; set; }

        [BsonElement("head3")]
        public bool ThirdHeadChip { get; set; }
    }

    public class KaraKrusSettlementResultEntity
    {
        public bool Kara { get; set; }

        public bool Krus { get; set; }

        [BsonElement("head1")]
        public bool OneHead { get; set; }

        [BsonElement("head2")]
        public bool TwoHead { get; set; }

        [BsonElement("head3")]
        public bool ThreeHead { get; set; }

        [BsonElement("tail3")]
        public bool ThreeTail { get; set; }
    }
}
