using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballslot_bets")]
    public class FootballSlotBet : BaseBetEntity
    {
        public decimal TotalAmount { get; set; }
    }
}