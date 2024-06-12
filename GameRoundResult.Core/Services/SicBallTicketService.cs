using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ISicBallTicketService : IDrawTicketService<SicBallRound, SicBallBet, SicBallBetLog, SicBallRoundResult, SicBallSettlementResult>
    { }

    public class SicBallTicketService : DrawTicketService<SicBallRound, SicBallBet, SicBallBetLog, SicBallRoundResult, SicBallSettlementResult>, ISicBallTicketService
    {
        public SicBallTicketService(ISicBallBetRepository repository) : base(repository)
        {
        }
    }
}