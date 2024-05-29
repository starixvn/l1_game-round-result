using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ILuckyThreeBetRepository : IDrawBetRepository<LuckyThreeRound, LuckyThreeBet, LuckyThreeBetLog, LuckyThreeRoundResult, LuckyThreeSettlementResult>
    { }

    public class LuckyThreeBetRepository : DrawBetRepository<LuckyThreeRound, LuckyThreeBet, LuckyThreeBetLog, LuckyThreeRoundResult, LuckyThreeSettlementResult>, ILuckyThreeBetRepository
    {
        public LuckyThreeBetRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}