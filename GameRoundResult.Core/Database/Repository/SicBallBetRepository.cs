using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISicBallBetRepository : IDrawBetRepository<SicBallRound, SicBallBet, SicBallBetLog, SicBallRoundResult, SicBallSettlementResult>
    { }

    public class SicBallBetRepository : DrawBetRepository<SicBallRound, SicBallBet, SicBallBetLog, SicBallRoundResult, SicBallSettlementResult>, ISicBallBetRepository
    {
        public SicBallBetRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}