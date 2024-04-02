using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities.LuckyNext
{
    [CollectionName("luckynext1_betlogs")]
    public class LuckyNext1BetLog : GameDrawBaseBetEntity
    {
        public decimal Amount { get; set; }
        public string Choice { get; set; }
    }

    [CollectionName("luckynext2_betlogs")]
    public class LuckyNext2BetLog : LuckyNext1BetLog { }
}
