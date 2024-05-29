using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("luckythree_betlogs")]
    public class LuckyThreeBetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }
}