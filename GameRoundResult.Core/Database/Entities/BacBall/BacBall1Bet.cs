using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball1_bets")]
    public class BacBall1Bet : GameDrawBaseBetEntity
    {
        public decimal Banker { get; set; }

        public decimal Player { get; set; }

        public decimal Tie { get; set; }

        public override decimal TotalBet => Banker + Player + Tie;
    }

    [CollectionName("bacball2_bets")]
    public class BacBall2Bet : BacBall1Bet
    {
    }

    [CollectionName("baccaratnumber_bets")]
    public class BaccaratNumberBet : BacBall1Bet
    {
    }

    [CollectionName("speedbaccaratnumber_bets")]
    public class SpeedBaccaratNumberBet : BacBall1Bet
    {
    }

    [CollectionName("vipbaccaratnumber_bets")]
    public class VIPBaccaratNumberBet : BacBall1Bet
    {
    }
}
