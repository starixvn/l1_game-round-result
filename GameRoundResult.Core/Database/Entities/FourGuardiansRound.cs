using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("fourguardians_rounds")]
    public class SlotGameRound : GameRound
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public SlotGameSettlementResult SettlementResult { get; set; }

        public IEnumerable<SlotGameBonusChest> BonusChests { get; set; }

        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public int? PlayerId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public string SiteId { get; set; }

        public string OperatorId { get; set; }

    }

    public class SlotGameBonusChest
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class SlotGameSettlementResult
    {
        public IEnumerable<SlotGameWinningLine> WinningPaylines { get; set; }

        public SlotGameBonus Bonus { get; set; }

        public SlotGameFreeSpin FreeSpins { get; set; }

        public SlotGameJackpot Jackpot { get; set; }
    }

    public class SlotGameJackpot
    {
        public byte WinningLine { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal WinningAmount { get; set; }
    }

    public class SlotGameWinningLine
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class SlotGameBonus
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class SlotGameFreeSpin
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}