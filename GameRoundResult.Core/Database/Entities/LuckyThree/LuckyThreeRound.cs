using System.Collections.Generic;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("luckythree_rounds")]
    public class LuckyThreeRound : GameDraw<LuckyThreeRoundResult, LuckyThreeSettlementResult>
    {
    }

    public class LuckyThreeRoundResult : GameDrawResultBase
    {
        public List<int> Balls { get; set; }
    }

    public class LuckyThreeSettlementResult : GameDrawBase
    {
        public bool Over { get; set; }
        public bool Under { get; set; }
        public bool Red2 { get; set; }
        public bool Red3 { get; set; }
        public bool Blue2 { get; set; }
        public bool Blue3 { get; set; }
    }

    [CollectionName("tripleluck_rounds")]
    public class TripleLuckRound : LuckyThreeRound { }

    [CollectionName("speedtripleluck_rounds")]
    public class SpeedTripleLuckRound : LuckyThreeRound { }

    [CollectionName("viptripleluck_rounds")]
    public class VIPTripleLuckRound : LuckyThreeRound { }
}