using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    public class LotteryOne : BaseBetEntity
    {
        public LotteryChoices Choices { get; set; }

        public LotteryOdds Odds { get; set; }

        public decimal TotalAmount { get; set; }
    }

    public class LotteryChoices
    {
        [BsonElement("4Sets")]
        public Dictionary<string, decimal> FourSets { get; set; }

        public Dictionary<string, decimal> Special { get; set; }

        public Dictionary<string, decimal> Head { get; set; }

        public Dictionary<string, decimal> Tail { get; set; }

        public Dictionary<string, decimal> Parlay2 { get; set; }

        public Dictionary<string, decimal> Parlay3 { get; set; }

        public Dictionary<string, decimal> Parlay4 { get; set; }

        [BsonElement("27Sets")]
        public Dictionary<string, decimal> TwentySevenSets { get; set; }

        public Dictionary<string, decimal> Others { get; set; }
    }

    public class LotteryOdds
    {
        [BsonElement("4Sets")]
        public decimal FourSets { get; set; }

        public decimal Special { get; set; }
        public decimal Head { get; set; }
        public decimal Tail { get; set; }
        public decimal Parlay2 { get; set; }
        public decimal Parlay3 { get; set; }
        public decimal Parlay4 { get; set; }

        [BsonElement("27Sets")]
        public decimal TwentySevenSets { get; set; }

        public decimal Others { get; set; }
    }
}