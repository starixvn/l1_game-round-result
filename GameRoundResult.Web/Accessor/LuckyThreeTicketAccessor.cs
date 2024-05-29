using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Accessor
{
    public class LuckyThreeTicketAccessor : DrawTicketAccessor<ILuckyThreeTicketService, LuckyThreeRound, LuckyThreeBet, LuckyThreeBetLog, LuckyThreeRoundResult, LuckyThreeSettlementResult, LuckyThreeTicketViewModel<LuckyThreeRound>>
    {
        public LuckyThreeTicketAccessor(ILuckyThreeTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}