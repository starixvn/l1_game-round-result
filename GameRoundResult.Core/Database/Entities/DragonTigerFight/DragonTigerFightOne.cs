using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.DragonTigerFight
{
    [CollectionName("dragontigerfight_ones")]
    public class DragonTigerFightOne : BaseBetEntity
    {
        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }

        public decimal BlackDragon { get; set; }

        public decimal RedDragon { get; set; }

        public decimal BlackTiger { get; set; }

        public decimal RedTiger { get; set; }

        public decimal TotalAmount { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public decimal TotalBet => Dragon + Tiger + Tie + BlackDragon + RedDragon + BlackTiger + RedTiger;
    }
}
