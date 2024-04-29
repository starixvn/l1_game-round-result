using GameRoundResult.Core.Database.Entities;
using System.Collections.Generic;

namespace GameRoundResult.Core.RoundHistory.Entities
{
    public class RoundHistoryRoundEntity : GameRound
    {
        public long DrawId { get; set; }        
    }
}
