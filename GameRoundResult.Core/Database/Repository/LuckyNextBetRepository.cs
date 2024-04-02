using GameRoundResult.Core.Database.Entities.LuckyNext;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ILuckyNext2BetRepository : IDrawBetRepository<LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog, LuckyNextRoundResult, LuckyNextSettlementResult> { }

    public interface ILuckyNext1BetRepository : IDrawBetRepository<LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog, LuckyNextRoundResult, LuckyNextSettlementResult> { }

    public class LuckyNext1BetRepository : DrawBetRepository<LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog, LuckyNextRoundResult, LuckyNextSettlementResult>, ILuckyNext1BetRepository
    {
        public LuckyNext1BetRepository(IMongoDatabase database) : base(database) { }
    }

    public class LuckyNext2BetRepository : DrawBetRepository<LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog, LuckyNextRoundResult, LuckyNextSettlementResult>, ILuckyNext2BetRepository
    {
        public LuckyNext2BetRepository(IMongoDatabase database) : base(database) { }
    }
}