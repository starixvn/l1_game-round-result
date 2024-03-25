using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballdice_rounds")]
    public class FootballDiceRound : GameRound
    {
        public FootballDiceResult Result { get; set; }
        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class FootballDiceResult
    {
        public IEnumerable<byte> Home { get; set; }
        public IEnumerable<byte> Away { get; set; }
    }

}