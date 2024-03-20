using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BacBall2
{
    [CollectionName("bacball2_bets")]
    public class BacBall2Bet : BaseBetEntity
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
