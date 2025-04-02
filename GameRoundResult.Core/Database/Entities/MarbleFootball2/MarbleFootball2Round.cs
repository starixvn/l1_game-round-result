using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marblefootball2_rounds")]
    public class MarbleFootball2Round : GameRound
    {
        public MarbleFootball2ResultEntity Result { get; set; }

        public MarbleFootball2SettlementResultEntity SettlementResult { get; set; }

        public MarbleFootball2MatchEntity Match { get; set; }
    }

    public class MarbleFootball2ResultEntity
    {
        public string FirstHalf { get; set; }

        public string SecondHalf { get; set; }
    }

    public class MarbleFootball2MatchEntity
    {
        public string Home { get; set; }

        public string Away { get; set; }
    }

    public class MarbleFootball2SettlementResultEntity
    {
        public bool Home { get; set; }

        public bool Away { get; set; }

        public bool Draw { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }

        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool HomeLive { get; set; }

        public bool AwayLive { get; set; }

        public bool DrawLive { get; set; }

        public bool OverLive { get; set; }

        public bool UnderLive { get; set; }

        public bool OddLive { get; set; }

        public bool EvenLive { get; set; }
    }
}
