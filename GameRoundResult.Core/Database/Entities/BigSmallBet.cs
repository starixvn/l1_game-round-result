using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("taixiu_cuocs")]
    public class BigSmallBet : BaseBetLogEntity
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        public bool Win { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }
    }

    [CollectionName("txturbo_cuocs")]
    public class TurboBigSmallBet: BigSmallBet
    {

    }
}