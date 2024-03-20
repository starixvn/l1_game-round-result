using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.BacBall2
{
    [CollectionName("bacball2_betlogs")]
    public class BacBall2BetLog : BaseBetLogEntity
    {
        public long DrawId { get; set; }
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
