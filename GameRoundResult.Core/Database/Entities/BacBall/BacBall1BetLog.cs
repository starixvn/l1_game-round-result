using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball1_betlogs")]
    public class BacBall1BetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }

    [CollectionName("bacball2_betlogs")]
    public class BacBall2BetLog : BacBall1BetLog
    {
    }
}
