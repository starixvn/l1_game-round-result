using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.ColorGame
{
    [CollectionName("colorgame_bets")]
    public class ColorGameBet : BaseBetEntity
    {
        public decimal Yellow { get; set; }

        public decimal Red { get; set; }

        public decimal Pink { get; set; }

        public decimal White { get; set; }

        public decimal Blue { get; set; }

        public decimal Green { get; set; }

        public decimal Hot { get; set; }

        public decimal Cold { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public double TotalAmount { get; set; }

        public decimal TotalBet => Yellow + Red + Pink + White + Blue + Green + Hot + Cold;
    }
}
