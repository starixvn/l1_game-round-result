using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("seball1_betlogs")]
    public class SeBall1BetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}