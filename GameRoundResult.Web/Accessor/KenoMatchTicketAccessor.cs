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
    public class KenoMatchTicketAccessor<TRoundEntity, TOneEntity, TBetEntity> : IGameTicketAccessor
        where TRoundEntity : KenoMatchRound
        where TOneEntity : KenoMatchOne
        where TBetEntity : KenoMatchBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public KenoMatchTicketAccessor(IGameBetService gameBetService,
            IMapper mapper,
            ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);
            var viewModel = new KenoMatchTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRoundEntity, KenoMatchRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneOffset)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                TotalBetWin = result.Item3?.Betwin ?? 0,
                Refund = result.Item3?.Refund ?? 0
            };
            if (result.Item2.Any())
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.First().Currency, request.OperatorId);
            }

            return viewModel;
        }
    }
}