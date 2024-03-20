using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("footballdice_rounds")]
    public class FootballDiceRound : GameRound
    {
        public FootballDiceResult Result { get; set; }
        public FootballDiceSettlementResult SettlementResult { get; set; }
    }

    public class FootballDiceResult
    {
        public IEnumerable<byte> Home { get; set; }
        public IEnumerable<byte> Away { get; set; }
    }

    public class FootballDiceSettlementResult 
    {
        public bool Home { get; set; }
        public bool Away { get; set; }
        public bool Draw { get; set; }
    }

}