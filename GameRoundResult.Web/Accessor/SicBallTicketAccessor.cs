using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Accessor
{
    public class SicBallTicketAccessor : DrawTicketAccessor<ISicBallTicketService, SicBallRound, SicBallBet, SicBallBetLog, SicBallRoundResult, SicBallSettlementResult, SicBallTicketViewModel<SicBallRound>>
    {
        public SicBallTicketAccessor(ISicBallTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}