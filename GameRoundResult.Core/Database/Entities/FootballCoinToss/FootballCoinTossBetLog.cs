using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.FootballCoin
{
    [CollectionName("footballcointoss_betlogs")]
    public class FootballCoinTossBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
