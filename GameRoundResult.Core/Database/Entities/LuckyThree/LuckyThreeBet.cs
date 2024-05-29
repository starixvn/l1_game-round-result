using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.GameDraw;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("luckythree_bets")]
    public class LuckyThreeBet : GameDrawBaseBetEntity
    {
        public decimal Over { get; set; }
        public decimal Under { get; set; }
        public decimal Red2 { get; set; }
        public decimal Red3 { get; set; }
        public decimal Blue2 { get; set; }
        public decimal Blue3 { get; set; }
        public override decimal TotalBet => Over + Under + Red2 + Red3 + Blue2 + Blue3;
    }
}