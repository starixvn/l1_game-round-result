using GameRoundResult.Core.Database.Entities.NextBall;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface INextBall1TicketService : IDrawTicketService<NextBall1Round, NextBall1Bet, NextBall1BetLog, NextBallRoundResult, NextBallSettlementResult> { }
    public interface INextBall2TicketService : IDrawTicketService<NextBall2Round, NextBall2Bet, NextBall2BetLog, NextBallRoundResult, NextBallSettlementResult> { }

    public class NextBall1TicketService : DrawTicketService<NextBall1Round, NextBall1Bet, NextBall1BetLog, NextBallRoundResult, NextBallSettlementResult>, INextBall1TicketService
    {
        public NextBall1TicketService(INextBall1BetRepository repository) : base(repository) { }
    }

    public class NextBall2TicketService : DrawTicketService<NextBall2Round, NextBall2Bet, NextBall2BetLog, NextBallRoundResult, NextBallSettlementResult>, INextBall2TicketService
    {
        public NextBall2TicketService(INextBall2BetRepository repository) : base(repository) { }
    }
}