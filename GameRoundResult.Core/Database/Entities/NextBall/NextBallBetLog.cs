using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.NextBall
{
    [CollectionName("nexball1_betlogs")]
    public class NextBall1BetLog : BaseBetLogEntity
    {
        public long DrawId { get; set; }
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }

    [CollectionName("nexball2_betlogs")]
    public class NextBall2BetLog : NextBall1BetLog { }
}
