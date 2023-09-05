using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.ColorGame
{
    [CollectionName("colorgame_betlogs")]
    public class ColorGameBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
