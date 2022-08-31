using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("fruitslot_bets")]
    public class FruitSlotBet : BaseBetEntity
    {
        public Dictionary<string, decimal> Odds { get; set; }
        public decimal TotalAmount { get; set; }
    }
}