using GameRoundResult.Core._Share;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("casinoholdempoker_cuocs")]
    public class CasinoHoldemPokerBet : BaseBetEntity
    {
        public decimal Aa { get; set; }

        public decimal AaOdds { get; set; }

        public decimal Ante { get; set; }

        public decimal AnteOdds { get; set; }

        public decimal Call { get; set; }

        public decimal CallOdds { get; set; }

        public DateTime CallTime { get; set; }

        public bool IsFold { get; set; }

        public IEnumerable<PokerCard> Cards { get; set; }

        public CombinationCard Result { get; set; }

        public CasinoHoldemPokerBetSettlementResult SettlementResult { get; set; }
    }

    public class CasinoHoldemPokerBetSettlementResult
    {
        public decimal Aa { get; set; }
        public decimal Ante { get; set; }
        public decimal Call { get; set; }
    }
}
