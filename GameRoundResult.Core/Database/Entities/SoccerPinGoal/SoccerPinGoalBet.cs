using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("soccerpingoal_bets")]
    public class SoccerPinGoalBet : RoundHistoryBetEntity
    {
        public decimal Red { get; set; }

        public decimal Blue { get; set; }

        public decimal Draw { get; set; }
    }
}
