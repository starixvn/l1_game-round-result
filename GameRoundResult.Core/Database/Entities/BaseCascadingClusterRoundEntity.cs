namespace GameRoundResult.Core.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class BaseCascadingClusterRoundEntity : GameRound
    {
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal TotalAmount { get; set; }

        public byte BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public byte BetMultiplier { get; set; }

        public bool FreeSpin { get; set; }
        public bool BuyFreeSpin { get; set; }

        public string Result { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        public int TotalMultiplier { get; set; }

        public int Multiplier { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal TotalTumbleWin { get; set; }

        public bool Paid { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public string SiteId { get; set; }

        public string PlayerId { get; set; }

        public BaseCascadingClusterSettlementResult SettlementResult { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public bool ReachMaxWin { get; set; }

        public string OperatorId { get; set; }
    }

    public class BaseCascadingClusterSettlementResult
    {
        public IEnumerable<BaseCascadingClusterTumble> Tumbles { get; set; }

        public BaseCascadingSlotFreeSpin FreeSpins { get; set; }

    }

    public class BaseCascadingClusterTumble
    {
        public int[][] Reels { get; set; } // 6x6 grid: reels[x][y] where x=column, y=row

        public int[][] ReelMultipliers { get; set; } // multiplier for each cell after detonating

        public IEnumerable<SymbolsInfo> Symbols { get; set; } // winning symbols info

        public int[][] NewSymbols { get; set; } // new symbols that drop down after detonation

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Win { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal RageMeter { get; set; }

        public bool[] RageStages { get; set; } // stage 1,2,3,4 - true means player reaches stage threshold

        public int? TriggeredStage { get; set; } // the corresponding stage causes the tumble, otherwise null
        public IEnumerable<SymbolPosition> TriggeredPositions { get; set; }
    }

    public class SymbolsInfo
    {
        public byte Symbol { get; set; }

        public IEnumerable<SymbolPosition> Position { get; set; }

        public byte Count { get; set; }

        public int Multiplier { get; set; }

        public decimal Odds { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal Win { get; set; }
    }

    public class SymbolPosition
    {
        public int X { get; set; }

        public int Y { get; set; }
    }

    public class BaseCascadingClusterFreeSpin
    {
        public byte Count { get; set; }

        public byte Odds { get; set; }

        public decimal? Win { get; set; }
    }
}
