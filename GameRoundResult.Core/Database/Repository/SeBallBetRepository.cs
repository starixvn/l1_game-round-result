using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISeBall1BetRepository : IDrawBetRepository<SeBall1Round, SeBall1Bet, SeBall1BetLog, SeBallRoundResult, SeBallSettlementResult>
    { }

    public class SeBall1BetRepository : DrawBetRepository<SeBall1Round, SeBall1Bet, SeBall1BetLog, SeBallRoundResult, SeBallSettlementResult>, ISeBall1BetRepository
    {
        public SeBall1BetRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}