using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marblefootball2_betlogs")]
    public class MarbleFootball2BetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
