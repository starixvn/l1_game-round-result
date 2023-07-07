using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.DragonTigerFight
{
    [CollectionName("dragontigerfight_betlogs")]
    public class DragonTigerFightBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
