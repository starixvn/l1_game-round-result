using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("winthreecards_rounds")]
    public class Win3CardsRound : GameRound
    {
        public Win3CardsResult Result { get; set; }

        public Win3CardsSettlementResult SettlementResult { get; set; }
    }

    public class Win3CardsResult
    {
        public Win3CardsHand Dragon { get; set; }

        public Win3CardsHand Phoenix { get; set; }
    }

    public class Win3CardsSettlementResult
    {
        public bool Dragon { get; set; }

        public bool Phoenix { get; set; }

        public bool Pair8Plus { get; set; }

        public bool Straight { get; set; }

        public bool Flush { get; set; }

        public bool StraightFlush { get; set; }

        public bool ThreeOfAKind { get; set; }
    }

    public class Win3CardsHand
    {
        public Win3CardsHandCards Cards { get; set; }
        public byte HandRankId { get; set; }
        public int CardRankId { get; set; }
    }

    public class Win3CardsHandCards
    {
        public PokerCard Card1 { get; set; }
        public PokerCard Card2 { get; set; }
        public PokerCard Card3 { get; set; }
    }
}