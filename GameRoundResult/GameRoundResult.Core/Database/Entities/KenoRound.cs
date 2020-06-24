using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoRound : GameRound
    {
        public IEnumerable<byte> Result { get; set; }

        public SettlementResult SettlementResult { get; set; }
    }

    public class SettlementResult
    {
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Gold { get; set; }
        public bool Wood { get; set; }
        public bool Water { get; set; }
        public bool Fire { get; set; }
        public bool Earth { get; set; }
    }
}