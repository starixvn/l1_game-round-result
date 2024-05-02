using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ISeBall1TicketService : IDrawTicketService<SeBall1Round, SeBall1Bet, SeBall1BetLog, SeBallRoundResult, SeBallSettlementResult>
    { }

    public class SeBall1TicketService : DrawTicketService<SeBall1Round, SeBall1Bet, SeBall1BetLog, SeBallRoundResult, SeBallSettlementResult>, ISeBall1TicketService
    {
        public SeBall1TicketService(ISeBall1BetRepository repository) : base(repository)
        {
        }
    }
}