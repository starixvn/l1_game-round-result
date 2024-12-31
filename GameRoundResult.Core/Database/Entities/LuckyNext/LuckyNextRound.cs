using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities.LuckyNext
{
    [CollectionName("luckynext1_rounds")]
    public class LuckyNext1Round : GameDraw<LuckyNextRoundResult, LuckyNextSettlementResult>
    {
    }

    public class LuckyNextRoundResult : GameDrawResultBase
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

    [CollectionName("luckynext_rounds")]
    public class LuckyNextRound : LuckyNext1Round
    {
    }

    [CollectionName("speedluckynext_rounds")]
    public class SpeedLuckyNextRound : LuckyNext1Round
    {
    }

    [CollectionName("vipluckynext_rounds")]
    public class VIPLuckyNextRound : LuckyNext1Round
    {
    }
}
