using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoMatchOne : BaseBetEntity
    {
        public decimal FHBlue { get; set; }
        public decimal FHRed { get; set; }
        public decimal FHOver { get; set; }
        public decimal FHUnder { get; set; }
        public decimal FHOdd { get; set; }
        public decimal FHEven { get; set; }

        public decimal FTBlue { get; set; }
        public decimal FTRed { get; set; }
        public decimal FTOver { get; set; }
        public decimal FTUnder { get; set; }
        public decimal FTOdd { get; set; }
        public decimal FTEven { get; set; }

        public decimal LiveFTBlue { get; set; }
        public decimal LiveFTRed { get; set; }
        public decimal LiveFTOver { get; set; }
        public decimal LiveFTUnder { get; set; }
        public decimal LiveFTOdd { get; set; }
        public decimal LiveFTEven { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal Refund { get; set; }
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