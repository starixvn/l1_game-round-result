using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.LuckyNext
{
    [CollectionName("luckynext1_rounds")]
    public class LuckyNext1Round : GameDraw<LuckyNextRoundResult, LuckyNextSettlementResult>
    {
    }

    public class LuckyNextRoundResult : GameDrawBase
    {
        public int Ball { get; set; }
    }

    public class LuckyNextSettlementResult : GameDrawBase
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }
    }

    [CollectionName("luckynext2_rounds")]
    public class LuckyNext2Round : LuckyNext1Round
    {
    }
}
