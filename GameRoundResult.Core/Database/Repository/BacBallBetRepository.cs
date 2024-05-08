using GameRoundResult.Core.Database.Entities.BacBall;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBacBall2BetRepository : IDrawBetRepository<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult> { }

    public interface IBacBall1BetRepository : IDrawBetRepository<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult> { }

    public class BacBall1BetRepository : DrawBetRepository<BacBall1Round, BacBall1Bet, BacBall1BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall1BetRepository
    {
        public BacBall1BetRepository(IMongoDatabase database) : base(database) { }
    }

    public class BacBall2BetRepository : DrawBetRepository<BacBall2Round, BacBall2Bet, BacBall2BetLog, BacBallRoundResult, BacBallSettlementResult>, IBacBall2BetRepository
    {
        public BacBall2BetRepository(IMongoDatabase database) : base(database) { }
    }
}