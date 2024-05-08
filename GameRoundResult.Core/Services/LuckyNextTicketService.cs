using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ILuckyNext1TicketService : IDrawTicketService<LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog, LuckyNextRoundResult, LuckyNextSettlementResult> { }
    public interface ILuckyNext2TicketService : IDrawTicketService<LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog, LuckyNextRoundResult, LuckyNextSettlementResult> { }

    public class LuckyNext1TicketService : DrawTicketService<LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog, LuckyNextRoundResult, LuckyNextSettlementResult>, ILuckyNext1TicketService
    {
        public LuckyNext1TicketService(ILuckyNext1BetRepository repository) : base(repository) { }
    }

    public class LuckyNext2TicketService : DrawTicketService<LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog, LuckyNextRoundResult, LuckyNextSettlementResult>, ILuckyNext2TicketService
    {
        public LuckyNext2TicketService(ILuckyNext2BetRepository repository) : base(repository) { }
    }
}