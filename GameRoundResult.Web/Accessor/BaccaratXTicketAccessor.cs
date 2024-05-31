using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
#pragma warning disable S2436 // Types and methods should not have too many generic parameters
    public class BaccaratXTicketAccessor<TRoundEntity, TBetEntity, TBetLogEntity> : IGameTicketAccessor
#pragma warning restore S2436 // Types and methods should not have too many generic parameters
        where TRoundEntity : BaccaratXRound
        where TBetEntity : BaccaratXBet
        where TBetLogEntity : BaccaratXBetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public BaccaratXTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var baccaratXResult = await gameBetService.GetAsync<TRoundEntity, TBetEntity, TBetLogEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new BaccaratXTicketViewModel
            {
                RoundResult = baccaratXResult.Item1?.ToViewModel<TRoundEntity, BaccaratXRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = baccaratXResult.Item2.Select(x => x.ToBetLogViewModel<TBetLogEntity, BaccaratXBetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = baccaratXResult.Item3?.Odds,
                TotalBet = baccaratXResult.Item3?.TotalAmount ?? 0,
                BetWin = baccaratXResult.Item3?.Betwin ?? 0,
                Multipliers = baccaratXResult.Item3?.Multipliers,
                Rate = baccaratXResult.Item3?.Rate ?? 0,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(baccaratXResult.Item3?.Currency, request.OperatorId)
            };
        }
    }
}
