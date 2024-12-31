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

    [CollectionName("tripleluck_betlogs")]
    public class TripleLuckBetLog : LuckyThreeBetLog { }

    [CollectionName("speedtripleluck_betlogs")]
    public class SpeedTripleLuckBetLog : LuckyThreeBetLog { }

    [CollectionName("viptripleluck_betlogs")]
    public class VIPTripleLuckBetLog : LuckyThreeBetLog { }

}