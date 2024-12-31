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

    [CollectionName("baccaratnumber_betlogs")]
    public class BaccaratNumberBetLog : BacBall1BetLog
    {
    }

    [CollectionName("speedbaccaratnumber_betlogs")]
    public class SpeedBaccaratNumberBetLog : BacBall1BetLog
    {
    }

    [CollectionName("vipbaccaratnumber_betlogs")]
    public class VIPBaccaratNumberBetLog : BacBall1BetLog
    {
    }
}
