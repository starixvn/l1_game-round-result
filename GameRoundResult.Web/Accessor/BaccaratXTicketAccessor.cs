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
    public class BaccaratXTicketAccessor : IGameTicketAccessor

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
            var baccaratXResult = await gameBetService.GetAsync<BaccaratXRound, BaccaratXBet, BaccaratXBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameConfigs.Name);

            return new BaccaratXTicketViewModel
            {
                RoundResult = baccaratXResult.Item1?.ToViewModel<BaccaratXRound, BaccaratXRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = baccaratXResult.Item2.Select(x => x.ToBetLogViewModel<BaccaratXBetLog, BaccaratXBetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = baccaratXResult.Item3?.Odds,
                TotalBet = baccaratXResult.Item3?.TotalAmount ?? 0,
                BetWin = baccaratXResult.Item3?.Betwin ?? 0,
                Fee = baccaratXResult.Item3?.Fee ?? 0,
                AmountExcludingFee = baccaratXResult.Item3?.Amount ?? 0,
                Multipliers = baccaratXResult.Item3?.Multipliers,
                Rate = baccaratXResult.Item3?.Rate ?? 0,
                ReachMaxWin = baccaratXResult.Item3?.ReachMaxWin ?? false,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(baccaratXResult.Item3?.Currency, request.OperatorId),
                ApplyMultiplier = request.GameConfigs.ApplyMultiplier
            };
        }
    }
}
