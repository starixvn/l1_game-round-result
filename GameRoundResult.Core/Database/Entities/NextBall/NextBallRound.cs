using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.NextBall
{
    [CollectionName("nextball1_rounds")]
    public class NextBall1Round : GameRound
    {
        public long DrawId { get; set; }

        public List<NextBallRoundResult> Result { get; set; }

        public List<NextBallSettlementResult> SettlementResult { get; set; }
    }

    public class NextBallRoundResult
    {
        public int Ball { get; set; }

        public long DrawId { get; set; }
    }

    public class NextBallSettlementResult
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }

        public long DrawId { get; set; }
    }

    [CollectionName("nextball2_rounds")]
    public class NextBall2Round : NextBall1Round
    {
    }
}
