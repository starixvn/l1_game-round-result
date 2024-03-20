using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.BacBall1
{
    [CollectionName("bacball1_betlogs")]
    public class BacBall1BetLog : BaseBetLogEntity
    {
        public long DrawId { get; set; }
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
