using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("vipbaccarat_phiens")]
    public class VipBaccaratRound : BaseBaccaratRoundEntity
    {
        public VipBaccaratResult Result { get; set; }

        public BaccaratResult SettlementResult { get; set; }
    }

    public class VipBaccaratResult
    {
        public Side Player { get; set; }

        public Side Banker { get; set; }
    }
}
