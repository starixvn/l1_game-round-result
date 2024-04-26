using GameRoundResult.Core.Database.Entities.RoundHistory;

namespace GameRoundResult.Core.Database.Entities.GameDraw
{
    public class GameDrawBaseBetEntity: RoundHistoryBetEntity
    {
        public virtual decimal TotalBet { get; }
    }
}
