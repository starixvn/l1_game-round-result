namespace GameRoundResult.Core.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class BaseCascadingSlotRoundEntity : GameRound
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal TotalAmount { get; set; }

        public byte BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public byte BetMultiplier { get; set; }

        public bool FreeSpin { get; set; }

        public string Result { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Betwin { get; set; }

        public int TotalMultiplier { get; set; }

        public int Multiplier { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal TotalTumbleWin { get; set; }

        public bool Paid { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public string SiteId { get; set; }

        public string PlayerId { get; set; }

        public BaseCascadingSlotSettlementResult SettlementResult { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public bool ReachMaxWin { get; set; }

        public string OperatorId { get; set; }
    }

    public class BaseCascadingSlotSettlementResult
    {
        public IEnumerable<BaseCascadingSlotTumble> Tumbles { get; set; }

        public BaseCascadingSlotFreeSpin FreeSpins { get; set; }

    }

    public class BaseCascadingSlotTumble
    {
        public Dictionary<string, BaseCascadingSlotWinningSymbol> Icons { get; set; } 

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Win { get; set; }

        public string OriginalBoard { get; set; }

        public IEnumerable<int> Multipliers { get; set; }
    }

    public class BaseCascadingSlotWinningSymbol
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Win { get; set; }
    }

    public class BaseCascadingSlotFreeSpin
    {
        public byte Count { get; set; }

        public byte Odds { get; set; }

        public decimal? Win { get; set; }
    }
}
