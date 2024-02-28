using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("baccaratball_betlogs")]
    public class BacBallBetLog : BaseBetLogEntity
    {
        public long DrawId { get; set; }
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}
