using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("blackjack_phiens")]
    public class BlackjackRound : GameRound
    {
        public IEnumerable<Card> Result { get; set; }

        public DateTime RoundStartTime { get; set; }

        public bool Ended { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public byte SettlementResult { get; set; }
    }

    public class Card
    {
        public string Rank { get; set; }

        public byte Suit { get; set; }
    }
}