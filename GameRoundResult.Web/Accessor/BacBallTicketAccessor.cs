using AutoMapper;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class BacBallTicketAccessor<ITicketService, D, B, BL> : IGameTicketAccessor
        where ITicketService : IDrawTicketService<D, B, BL, BacBallRoundResult, BacBallSettlementResult>
         where D : BacBall1Round
        where B : BacBall1Bet
        where BL : BacBall1BetLog
    {
        private readonly ITicketService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public BacBallTicketAccessor(ITicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
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

    public class BacBall1TicketAccessor : BacBallTicketAccessor<IBacBall1TicketService, BacBall1Round, BacBall1Bet, BacBall1BetLog>
    {
        public BacBall1TicketAccessor(IBacBall1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class BacBall2TicketAccessor : BacBallTicketAccessor<IBacBall2TicketService, BacBall2Round, BacBall2Bet, BacBall2BetLog>
    {
        public BacBall2TicketAccessor(IBacBall2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}