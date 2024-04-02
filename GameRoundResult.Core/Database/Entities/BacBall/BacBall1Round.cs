using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball1_rounds")]
    public class BacBall1Round : GameDraw<BacBallRoundResult, BacBallSettlementResult>
    {
    }   

    public class BacBallRoundResult : GameDrawResultBase
    {
        public int Player { get; set; }

        public int Banker { get; set; }
    }

    public class BacBallSettlementResult: GameDrawBase
    {
        public bool Player { get; set; }

        public bool Banker { get; set; }

        public bool Tie { get; set; }

    }
    
    [CollectionName("bacball2_rounds")]
    public class BacBall2Round : BacBall1Round
    {
    }

}
