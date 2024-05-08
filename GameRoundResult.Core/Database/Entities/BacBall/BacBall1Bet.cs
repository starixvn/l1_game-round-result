using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall
{
    [CollectionName("bacball1_bets")]
    public class BacBall1Bet : GameDrawBaseBetEntity
    {
        public decimal Banker { get; set; }

        public decimal Player { get; set; }

        public decimal Tie { get; set; }


        public double TotalAmount { get; set; }

        public override decimal TotalBet => Banker + Player + Tie;
    }

    [CollectionName("bacball2_bets")]
    public class BacBall2Bet : BacBall1Bet
    {
    }
}
