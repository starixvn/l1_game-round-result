using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("winthreecards_bets")]
    public class Win3CardsBet: BaseBetEntity
    {
        public Dictionary<string, decimal> Odds { get; set; }

        public decimal Dragon { get; set; }

        public decimal Phoenix { get; set; }

        public decimal Pair8Plus { get; set; }

        public decimal Straight { get; set; }

        public decimal FLush { get; set; }

        public decimal StraightFlush { get; set; }

        [BsonElement("threeOfAKind")]
        public decimal ThreeKind { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return  Dragon + Phoenix + FLush + StraightFlush + Straight + Pair8Plus + ThreeKind;
            }
        }
    }
}
