using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall1
{
    [CollectionName("bacball1_rounds")]
    public class BacBall1Round : GameRound
    {
        public long DrawId { get; set; }

        public List<BacBall1RoundResult> Result { get; set; }

        public List<BacBall1SettlementResult> SettlementResult { get; set; }
    }   

    public class BacBall1RoundResult
    {
        public int Player { get; set; }

        public int Banker { get; set; }

        public long DrawId { get; set; }
    }

    public class BacBall1SettlementResult
    {
        public bool Player { get; set; }

        public bool Banker { get; set; }

        public bool Tie { get; set; }

        public long DrawId { get; set; }
    }
}
