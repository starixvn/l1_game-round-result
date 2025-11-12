using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

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

        public Dictionary<decimal, Dictionary<decimal, List<decimal>>> Odds { get; set; }

        public int GameMode { get; set; }

        public PlinkoSettlement SettlementResult { get; set; }

        public bool ReachMaxWin { get; set; }

        public LightningBoard LightningBoard { get; set; }
    }

    public class PlinkoSettlement
    {
        public int SlotIndex { get; set; }

        public double Multiplier { get; set; }

        public List<PegMultiplier> ReachedPegMultipliers { get; set; }
    }

    public class LightningBoard
    {
        public List<decimal> Odds { get; set; }
        public List<PegMultiplier> PegMultipliers { get; set; }
    }

    public class PegMultiplier
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public decimal Multiplier { get; set; }
    }
}
