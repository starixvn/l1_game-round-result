using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class HeroesSlotRound : GameRound
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public HeroesSlotSettlementResult SettlementResult { get; set; }

        public IEnumerable<HeroesSlotBonusChest> BonusChests { get; set; }
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }
    }

    public class HeroesSlotBonusChest
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class HeroesSlotSettlementResult
    {
        public IEnumerable<HeroesSlotWinningLine> WinningPaylines { get; set; }

        public HeroesSlotBonus Bonus { get; set; }

        public HeroesSlotFreeSpin FreeSpins { get; set; }

        public HeroesSlotJackpot Jackpot { get; set; }
    }

    public class HeroesSlotJackpot
    {
        public byte WinningLine { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal WinningAmount { get; set; }
    }

    public class HeroesSlotWinningLine
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class HeroesSlotBonus
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class HeroesSlotFreeSpin
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}