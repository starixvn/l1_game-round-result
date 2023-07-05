using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.DragonTigerFight
{
    [CollectionName("dragontigerfight_bets")]
    public class DragonTigerFightBet : BaseBetLogEntity
    {
        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }

        public decimal BlackDragon { get; set; }

        public decimal RedDragon { get; set; }

        public decimal BlackTiger { get; set; }

        public decimal RedTiger { get; set; }
    }
}
