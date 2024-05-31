using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("winthreecards_bets")]
    public class Win3CardsBet : BaseBetEntity
    {
        public decimal Dragon { get; set; }

        public decimal Phoenix { get; set; }

        public decimal Pair8Plus { get; set; }

        public decimal Straight { get; set; }

        public decimal Flush { get; set; }

        public decimal StraightFlush { get; set; }

        public decimal ThreeOfAKind { get; set; }

        public decimal TotalBet => Dragon + Phoenix + Pair8Plus + Straight + Flush + StraightFlush + ThreeOfAKind;
    }
}