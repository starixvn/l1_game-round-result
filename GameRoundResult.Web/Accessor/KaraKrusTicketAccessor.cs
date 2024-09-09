using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.KaraKrus;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class KaraKrusTicketAccessor<TRoundEntity, TBetEntity, TBetLogEntity> : IGameTicketAccessor
        where TRoundEntity : KaraKrusRound
        where TBetEntity : KaraKrusBet
        where TBetLogEntity : KaraKrusBetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public KaraKrusTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TBetEntity, TBetLogEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new KaraKrusTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRoundEntity, KaraKrusRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<TBetLogEntity, KaraKrusBetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                Rate = result.Item3?.Rate ?? 0,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item3?.Currency, request.OperatorId),
            };
        }
    }
}
