using AutoMapper;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Accessor
{
    public class LuckyNext1TicketAccessor : DrawTicketAccessor<ILuckyNext1TicketService, LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog, LuckyNextRoundResult, LuckyNextSettlementResult, LuckyNextTicketViewModel<LuckyNext1Round>>
    {
        public LuckyNext1TicketAccessor(ILuckyNext1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }

    public class LuckyNext2TicketAccessor : DrawTicketAccessor<ILuckyNext2TicketService, LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog, LuckyNextRoundResult, LuckyNextSettlementResult, LuckyNextTicketViewModel<LuckyNext2Round>>
    {
        public LuckyNext2TicketAccessor(ILuckyNext2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}