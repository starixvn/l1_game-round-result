using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.CoinMining
{
    [CollectionName("goldanddragon_betlogs")]
    public class GoldAndDragonBetLog : BaseBetLogEntity
    {
        public decimal WinAmount { get; set; }
    }
}
