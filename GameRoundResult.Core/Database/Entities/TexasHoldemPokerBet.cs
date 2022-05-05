using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("texasholdempoker_cuocs")]
    public class TexasHoldemPokerBet : BaseBetEntity
    {
        public decimal Ante { get; set; }

        public decimal AnteOdds { get; set; }

        public decimal Turn { get; set; }

        public decimal TurnOdds { get; set; }

        public decimal River { get; set; }

        public decimal RiverOdds { get; set; }

        public decimal Call { get; set; }

        public decimal CallOdds { get; set; }

        public bool IsFold { get; set; }

        public DateTime CallTime { get; set; }

        public DateTime TurnTime { get; set; }

        public DateTime RiverTime { get; set; }

        public IEnumerable<PokerCard> Cards { get; set; }

        public CombinationCard Result { get; set; }

        public TexasHoldemPokerBetSettlementResult SettlementResult { get; set; }
    }

    public class TexasHoldemPokerBetSettlementResult
    {
        public decimal Ante { get; set; }

        public decimal Call { get; set; }

        public decimal Turn { get; set; }

        public decimal River { get; set; }
    }
}
