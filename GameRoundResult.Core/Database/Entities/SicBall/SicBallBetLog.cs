using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("sicball_betlogs")]
    public class SicBallBetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}