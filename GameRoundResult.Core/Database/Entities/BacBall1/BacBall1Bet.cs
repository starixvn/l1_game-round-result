using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall1
{
    [CollectionName("bacball1_bets")]
    public class BacBall1Bet : BaseBetEntity
    {
        public long DrawId { get; set; }

        public decimal Banker { get; set; }

        public decimal Player { get; set; }

        public decimal Tie { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public double TotalAmount { get; set; }

        public decimal TotalBet => Banker + Player + Tie;
    }
}
