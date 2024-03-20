using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall2
{
    [CollectionName("bacball2_rounds")]
    public class BacBall2Round : GameRound
    {
        public long DrawId { get; set; }

        public List<BacBall2RoundResult> Result { get; set; }

        public List<BacBall2SettlementResult> SettlementResult { get; set; }
    }   

    public class BacBall2RoundResult
    {
        public int Player { get; set; }

        public int Banker { get; set; }

        public long DrawId { get; set; }
    }

    public class BacBall2SettlementResult
    {
        public bool Player { get; set; }

        public bool Banker { get; set; }

        public bool Tie { get; set; }

        public long DrawId { get; set; }
    }
}
