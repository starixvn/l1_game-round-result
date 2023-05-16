using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class SlotGameRound : BaseSlotRoundEntity
    {
        public decimal Bet { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public SlotGameSettlementResult SettlementResult { get; set; }

        public IEnumerable<SlotGameBonusChest> BonusChests { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public SlotGameJackpotContribution JackpotContribution { get; set; }
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

    public class SlotGameJackpotContribution 
    {
        public decimal ContributionRate { get; set; }
        public decimal BaseContributionAmount { get; set; }
    }
}