using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

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


    [CollectionName("baccaratnumber_rounds")]
    public class BaccaratNumberRound : BacBall1Round
    {
    }

    [CollectionName("speedbaccaratnumber_rounds")]
    public class SpeedBaccaratNumberRound : BacBall1Round
    {
    }

    [CollectionName("vipbaccaratnumber_rounds")]
    public class VIPBaccaratNumberRound : BacBall1Round
    {
    }
}
