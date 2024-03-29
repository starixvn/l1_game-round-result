using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities.NextBall
{
    [CollectionName("nextball1_betlogs")]
    public class NextBall1BetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }

    [CollectionName("nextball2_betlogs")]
    public class NextBall2BetLog : NextBall1BetLog { }
}
