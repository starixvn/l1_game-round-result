using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("threecards_phiens")]
    public class ThreeCardsRound : GameRound
    {
        public IEnumerable<Card> Result { get; set; }
        public ThreeCardsSettlementResult SettlementResult { get; set; }
    }

    public class ThreeCardsSettlementResult
    {
        public bool Red { get; set; }
        public bool Black { get; set; }
        public bool Diamonds { get; set; }
        public bool Hearts { get; set; }
        public bool Spades { get; set; }
        public bool Clubs { get; set; }
    }
}