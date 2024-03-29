using GameRoundResult.Core.Database.Entities.NextBall;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface INextBall2BetRepository : IDrawBetRepository<NextBall2Round, NextBall2Bet, NextBall2BetLog, NextBallRoundResult, NextBallSettlementResult> { }

    public interface INextBall1BetRepository : IDrawBetRepository<NextBall1Round, NextBall1Bet, NextBall1BetLog, NextBallRoundResult, NextBallSettlementResult> { }

    public class NextBall1BetRepository : DrawBetRepository<NextBall1Round, NextBall1Bet, NextBall1BetLog, NextBallRoundResult, NextBallSettlementResult>, INextBall1BetRepository
    {
        public NextBall1BetRepository(IMongoDatabase database) : base(database) { }
    }

    public class NextBall2BetRepository : DrawBetRepository<NextBall2Round, NextBall2Bet, NextBall2BetLog, NextBallRoundResult, NextBallSettlementResult>, INextBall2BetRepository
    {
        public NextBall2BetRepository(IMongoDatabase database) : base(database) { }
    }
}