using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinToss
{
    [CollectionName("cointoss_betlogs")]
    public class CoinTossBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
