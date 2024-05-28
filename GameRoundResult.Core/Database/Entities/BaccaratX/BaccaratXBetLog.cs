using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class BaccaratXBetLog : BaseBetLogEntity
    {
        public decimal Fee { get; set; }
    }

    [CollectionName("bac81_betlogs")]
    public class Bac81BetLog : BaccaratXBetLog
    {
    }
}