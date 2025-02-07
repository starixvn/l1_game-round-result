using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinMining
{
    [CollectionName("coinmining_betlogs")]
    public class CoinMiningBetLog : BaseBetLogEntity
    {
        public decimal WinAmount { get; set; }
        public decimal Multiplier { get; set; }
        public decimal Increment { get; set; }
    }
}
