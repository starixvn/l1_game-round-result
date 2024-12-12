using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marblefootball_rounds")]
    public class MarbleFootballRound : GameRound
    {
        public MarbleFootballResultEntity Result { get; set; }

        public MarbleFootballSettlementResultEntity SettlementResult { get; set; }

        public MarbleFootballMatchEntity Match { get; set; }
    }

    public class MarbleFootballResultEntity
    {
        public string FirstHalf { get; set; }

        public string SecondHalf { get; set; }
    }

    public class MarbleFootballMatchEntity
    {
        public string Home { get; set; }

        public string Away { get; set; }
    }

    public class MarbleFootballSettlementResultEntity
    {
        public bool Home { get; set; }

        public bool Away { get; set; }

        public bool Draw { get; set; }

        public bool Draw4 { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }

        public bool Odd { get; set; }

        public bool Even { get; set; }
    }
}
