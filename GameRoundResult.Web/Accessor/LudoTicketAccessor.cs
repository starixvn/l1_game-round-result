using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;
using System.Linq;
using GameRoundResult.Core.Database.Entities;

namespace GameRoundResult.Web.Accessor
{
    public class LudoTicketAccessor<TRoundEntity, TBetEntity, TBetLogEntity> : IGameTicketAccessor
        where TRoundEntity : LudoRound
        where TBetEntity : LudoBet
        where TBetLogEntity : LudoBetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public LudoTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TBetEntity, TBetLogEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new LudoTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRoundEntity, LudoRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<TBetLogEntity, LudoBetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                Rate = result.Item3?.Rate ?? 0,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
                ReachMaxWin = result.Item3?.ReachMaxWin ?? false,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item3?.Currency, request.OperatorId),
            };
        }
    }
}
