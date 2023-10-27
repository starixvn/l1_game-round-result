using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.BandarQiuQiu
{
    [CollectionName("bandarqiuqiu_betlogs")]
    public class BandarQiuQiuBetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
