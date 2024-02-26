using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball_rounds")]
    public class BacBallRound : GameRound
    {
        public BacBallRoundResult Result { get; set; }

        public Dictionary<string, int> SettlementResult { get; set; }
    }   

    public class BacBallRoundResult
    {
        public BacBallResultItem Banker { get; set; }

        public BacBallResultItem Spade { get; set; }

        public BacBallResultItem Heart { get; set; }

        public BacBallResultItem Club { get; set; }

        public BacBallResultItem Diamond { get; set; }
    }

    public class BacBallResultItem
    {
        public List<string> Dominoes { get; set; }

        public int HandRankingId { get; set; }

        public IEnumerable<int> PipsOfSet { get; set; }
    }
}
