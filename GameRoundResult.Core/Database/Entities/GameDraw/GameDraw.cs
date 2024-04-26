using GameRoundResult.Core.RoundHistory.Entities;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.GameDraw
{
    public class GameDraw<Round, Settlement> : RoundHistoryRoundEntity
    {
        public List<Round> Result { get; set; }

        public List<Settlement> SettlementResult { get; set; }
    }
}
