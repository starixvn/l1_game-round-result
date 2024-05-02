using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Accessor
{
    public class SeBall1TicketAccessor : DrawTicketAccessor<ISeBall1TicketService, SeBall1Round, SeBall1Bet, SeBall1BetLog, SeBallRoundResult, SeBallSettlementResult, SeBallTicketViewModel<SeBall1Round>>
    {
        public SeBall1TicketAccessor(ISeBall1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}