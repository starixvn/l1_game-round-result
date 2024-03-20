using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball1_rounds")]
    public class BacBallRound : GameRound
    {
        public long DrawId { get; set; }

        public List<BacBallRoundResult> Result { get; set; }

        public List<BacBallSettlementResult> SettlementResult { get; set; }
    }   

    public class BacBallRoundResult
    {
        public int Player { get; set; }

        public int Banker { get; set; }

        public long DrawId { get; set; }
    }

    public class BacBallSettlementResult
    {
        public bool Player { get; set; }

        public bool Banker { get; set; }

        public bool Tie { get; set; }

        public long DrawId { get; set; }
    }
}
