using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class PlinkoGameRound : GameRound
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Amount { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal TotalAmount { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public string PlayerId { get; set; }

        public string SiteId { get; set; }

        public string Currency { get; set; }

        public string OperatorId { get; set; }

        public decimal Rate { get; set; }

        public PlinkoSettlement SettlementResult { get; set; }

        public bool ReachMaxWin { get; set; }
    }

    public class PlinkoSettlement
    {
        public int SlotIndex { get; set; }

        public double Multiplier { get; set; }
    }
}
