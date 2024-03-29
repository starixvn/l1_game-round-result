using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.NextBall
{
    [CollectionName("nextball1_rounds")]
    public class NextBall1Round : GameDraw<NextBallRoundResult, NextBallSettlementResult>
    {
    }

    public class NextBallRoundResult : GameDrawBase
    {
        public int Ball { get; set; }
    }

    public class NextBallSettlementResult : GameDrawBase
    {
        public bool Odd { get; set; }

        public bool Even { get; set; }

        public bool Over { get; set; }

        public bool Under { get; set; }
    }

    [CollectionName("nextball2_rounds")]
    public class NextBall2Round : NextBall1Round
    {
    }
}
