using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.NextBall
{
    [CollectionName("nextball1_bets")]
    public class NextBall1Bet : GameDrawBaseBetEntity
    {
        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal Over { get; set; }
        public decimal Under { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public double TotalAmount { get; set; }

        public override decimal TotalBet => Odd + Even + Over + Under;
    }

    [CollectionName("nextball2_bets")]
    public class NextBall2Bet : NextBall1Bet
    {
    }
}


