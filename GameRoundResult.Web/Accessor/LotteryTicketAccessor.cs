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
    public class LotteryTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public LotteryTicketAccessor(IGameBetService gameBetService,
            IMapper mapper,
            ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<LotteryRound, LotteryOne, LotteryBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            var ticketViewModel = new LotteryTicketViewModel
            {
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
            };

            if (result.Item2.Any())
            {
                ticketViewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.First().Currency, request.OperatorId);
            }

            if (result.Item1 != null)
            {
                ticketViewModel.RoundResult = result.Item1.ToViewModel<LotteryRound, LotteryRoundResultViewModel>(mapper, request.TimeZoneInfo);
                ticketViewModel.SettlementResult = mapper.Map<LotterySettlementResultViewModel>(result.Item1.SettlementResult);
            }

            if (result.Item3 != null)
            {
                ticketViewModel.TotalBet = result.Item3.TotalAmount;
                ticketViewModel.TotalBetWin = result.Item3.Betwin;
                ticketViewModel.Odds = mapper.Map<LotteryOddsViewModel>(result.Item3?.Odds);
                ticketViewModel.Choices = mapper.Map<LotteryChoicesViewModel>(result.Item3.Choices);
            }

            return ticketViewModel;
        }
    }
}