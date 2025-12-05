using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("marbles158_rounds")]
    public class Marbles158Round : GameRound
    {
        public Dictionary<int, Marbles158ResultEntity> Result { get; set; }

        public Dictionary<int, Marbles158SettlementResultEntity> SettlementResult { get; set; }

        public Marbles158MatchEntity Match { get; set; }
    }

    public class Marbles158ResultEntity
    {
        public int Phase { get; set; }
        public string Result { get; set; }
    }

    public class Marbles158MatchEntity
    {
        public string Home { get; set; }

        public string Away { get; set; }
    }

    public class Marbles158SettlementResultEntity
    {
        public bool Home { get; set; }

        public bool Away { get; set; }

        public bool Draw { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }

        public bool Odd { get; set; }

        public bool Even { get; set; }
    }
}
