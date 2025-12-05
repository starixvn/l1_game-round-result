using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marbles158_betlogs")]
    public class Marbles158BetLog : BaseBetLogEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
        public int Index { get; set; }
        public string LiveScore { get; set; }
    }
}
