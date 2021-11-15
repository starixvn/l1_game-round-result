using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("fourguardians_rounds")]
    public class FourGuardiansRound : GameRound
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public FourGuardiansSettlementResult SettlementResult { get; set; }

        public IEnumerable<FourGuardiansBonusChest> BonusChests { get; set; }
        public bool Paid { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal BetWin { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public int? MemberId { get; set; }

        public string SiteId { get; set; }
    }

    public class FourGuardiansBonusChest
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class FourGuardiansSettlementResult
    {
        public IEnumerable<FourGuardiansWinningLine> WinningPaylines { get; set; }

        public FourGuardiansBonus Bonus { get; set; }

        public FourGuardiansFreeSpin FreeSpins { get; set; }

        public FourGuardiansJackpot Jackpot { get; set; }
    }

    public class FourGuardiansJackpot
    {
        public byte WinningLine { get; set; }

        [BsonRepresentation(BsonType.Decimal128, AllowTruncation = true)]
        public decimal WinningAmount { get; set; }
    }

    public class FourGuardiansWinningLine
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class FourGuardiansBonus
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class FourGuardiansFreeSpin
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}