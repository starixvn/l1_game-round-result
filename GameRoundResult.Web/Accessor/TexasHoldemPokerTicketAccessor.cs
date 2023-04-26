using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class TexasHoldemPokerTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public TexasHoldemPokerTicketAccessor(IGameBetService gameBetService,
            IMapper mapper,
            ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TexasHoldemPokerRound, TexasHoldemPokerBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);
            var viewModel = new TexasHoldemPokerTicketViewModel
            {
                Round = result.Item1?.ToViewModel<TexasHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>(mapper, request.TimeZoneInfo),
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