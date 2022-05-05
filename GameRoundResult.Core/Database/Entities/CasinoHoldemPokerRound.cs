using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("casinoholdempoker_phiens")]
    public class CasinoHoldemPokerRound : GameRound
    {
        public CasinoHoldemPokerResult Result { get; set; }

        public CombinationCard SettlementResult { get; set; }

        public DateTime RoundStartTime { get; set; }

        public bool Ended { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public bool? IsSwappedOrHold { get; set; }
    }

    public class CasinoHoldemPokerResult
    {
        public IEnumerable<PokerCard> Dealer { get; set; }
        public IEnumerable<PokerCard> CommunityCards { get; set; }
    }

    public class CombinationCard
    {
        public IEnumerable<PokerCard> Cards { get; set; }
        public IEnumerable<PokerCard> CombinationCards { get; set; }
        public bool? IsQualified { get; set; }
        [BsonElement("id")]
        public int HandRankId { get; set; }
    }

    public class PokerCard
    {
        public byte Rank { get; set; }

        public byte Suit { get; set; }
    }
}
