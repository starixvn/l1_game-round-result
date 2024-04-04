using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballslot_rounds")]
    public class FootballSlotRound : GameRound
    {
        public FootballSlotResult Result { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class FootballSlotResult
    {
        public IEnumerable<string> Symbols { get; set; }
        public byte Number { get; set; }
    }
}