using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ILuckyThreeTicketService : IDrawTicketService<LuckyThreeRound, LuckyThreeBet, LuckyThreeBetLog, LuckyThreeRoundResult, LuckyThreeSettlementResult>
    { }

    public class LuckyThreeTicketService : DrawTicketService<LuckyThreeRound, LuckyThreeBet, LuckyThreeBetLog, LuckyThreeRoundResult, LuckyThreeSettlementResult>, ILuckyThreeTicketService
    {
        public LuckyThreeTicketService(ILuckyThreeBetRepository repository) : base(repository)
        {
        }
    }
}