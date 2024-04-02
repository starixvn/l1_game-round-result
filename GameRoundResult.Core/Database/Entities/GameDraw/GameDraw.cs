using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.GameDraw
{
    public class GameDraw<Round, Settlement> : GameRound
    {
        public long DrawId { get; set; }

        public List<Round> Result { get; set; }

        public List<Settlement> SettlementResult { get; set; }
    }

}
