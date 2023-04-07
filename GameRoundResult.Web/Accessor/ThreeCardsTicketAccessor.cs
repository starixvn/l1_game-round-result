using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class ThreeCardsTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public ThreeCardsTicketAccessor(IGameBetService gameBetService,
            IMapper mapper,
           ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request, GameConfigModel gameConfigs)
        {
            var result = await gameBetService.GetAsync<ThreeCardsRound, ThreeCardsBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);
            var viewModel = new ThreeCardsTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<ThreeCardsRound, ThreeCardsRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
            if (result.Item2 != null)
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.Currency, result.Item2.OperatorId);
            }
            return viewModel;
        }
    }
}