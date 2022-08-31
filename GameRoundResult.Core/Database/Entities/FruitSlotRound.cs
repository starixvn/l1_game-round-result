using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("fruitslot_rounds")]
    public class FruitSlotRound : GameRound
    {
        public FruitSlotResult Result { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class FruitSlotResult
    {
        public IEnumerable<string> Symbols { get; set; }
        public byte Number { get; set; }
    }
}