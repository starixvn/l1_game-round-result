using System;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    public class BlackjackRound : GameRound
    {
        public IEnumerable<BlackjackCard> Result { get; set; }

        public DateTime RoundStartTime { get; set; }

        public bool Ended { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        public byte SettlementResult { get; set; }
    }

    public class BlackjackCard
    {
        public string Rank { get; set; }

        public byte Suit { get; set; }
    }
}
