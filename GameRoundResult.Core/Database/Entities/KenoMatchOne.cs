using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoMatchOne : BaseBetEntity
    {
        public decimal PreHTHome { get; set; }
        public decimal PreHTAway { get; set; }
        public decimal PreHTOver { get; set; }
        public decimal PreHTUnder { get; set; }
        public decimal PreHTOdd { get; set; }
        public decimal PreHTEven { get; set; }

        public decimal PreFTHome { get; set; }
        public decimal PreFTAway { get; set; }
        public decimal PreFTOver { get; set; }
        public decimal PreFTUnder { get; set; }
        public decimal PreFTOdd { get; set; }
        public decimal PreFTEven { get; set; }

        public decimal LiveFTHome { get; set; }
        public decimal LiveFTAway { get; set; }
        public decimal LiveFTOver { get; set; }
        public decimal LiveFTUnder { get; set; }
        public decimal LiveFTOdd { get; set; }
        public decimal LiveFTEven { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal Refund { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }
    }

    [CollectionName("kenomatch1_ones")]
    public class KenoMatch1One : KenoMatchOne
    {

    }

    [CollectionName("kenomatch2_ones")]
    public class KenoMatch2One : KenoMatchOne
    {

    }
}