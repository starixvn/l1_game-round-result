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

    [CollectionName("luckynext_betlogs")]
    public class LuckyNextBetLog : LuckyNext1BetLog { }

    [CollectionName("speedluckynext_betlogs")]
    public class SpeedLuckyNextBetLog : LuckyNext1BetLog { }

    [CollectionName("vipluckynext_betlogs")]
    public class VIPLuckyNextBetLog : LuckyNext1BetLog { }
}
