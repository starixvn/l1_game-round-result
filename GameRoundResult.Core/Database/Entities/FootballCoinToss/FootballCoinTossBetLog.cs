using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.FootballCoinToss
{
    [CollectionName("footballcointoss_betlogs")]
    public class FootballCoinTossBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
