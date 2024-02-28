using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class BacBallTicketAccessor : IGameTicketAccessor
    {
        private readonly IBacBallTicketService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public BacBallTicketAccessor(IBacBallTicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            var viewModel = new BacBallTicketViewModel
            {
                RoundResult = result.Item1,
                BetLogs = result.Item3?.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                Odds = result.Item2?.Odds,
                TotalBet = result.Item2?.TotalBet ?? 0,
                BetWin = result.Item2?.Betwin ?? 0,
                DrawId = request.RoundId
            };
            if (!string.IsNullOrEmpty(result.Item2?.Currency))
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.Currency, request.OperatorId);
            }

            return viewModel;
        }
    }
}