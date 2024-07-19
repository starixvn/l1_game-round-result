using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.BandarQiuQiu
{
    [CollectionName("bandarqiuqiu_bets")]
    public class BandarQiuQiuBet : BaseBetEntity
    {
        public decimal Spade { get; set; }

        public decimal Heart { get; set; }

        public decimal Club { get; set; }

        public decimal Diamond { get; set; }

        public double TotalAmount { get; set; }

        public decimal TotalBet => Spade + Heart + Club + Diamond;
    }
}
