using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class SeDie3TicketAccessor<TRoundEntity, TBetEntity, TBetLogEntity> : IGameTicketAccessor
        where TRoundEntity : SeDie3Round
        where TBetEntity : SeDie3Bet
        where TBetLogEntity : SeDie3BetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public SeDie3TicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TBetEntity, TBetLogEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new SeDie3TicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRoundEntity, SeDie3RoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<TBetLogEntity, SeDie3BetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                Rate = result.Item3?.Rate ?? 0,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
                FreeBet = result.Item3?.FreeBet ?? false,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item3?.Currency, request.OperatorId),
            };
        }
    }
}
