using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("taixiu_ones")]
    public class BigSmallOne : BaseBetEntity
    {
        public bool Win { get; set; }

        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }
    }

    [CollectionName("txturbo_ones")]
    public class TurboBigSmallOne : BigSmallOne
    {
    }
}