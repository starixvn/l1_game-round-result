using AutoMapper;
using GameRoundResult.Core.Database.Entities.NextBall;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class NextBallTicketAccessor<ITicketService, Draw, Bets, BetLogs> : IGameTicketAccessor
        where ITicketService : IDrawTicketService<Draw, Bets, BetLogs, NextBallRoundResult, NextBallSettlementResult>
        where Draw : NextBall1Round
        where Bets : NextBall1Bet
        where BetLogs : NextBall1BetLog
    {
        private readonly ITicketService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public NextBallTicketAccessor(ITicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            var viewModel = new NextBallTicketViewModel
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

    public class NextBall1TicketAccessor : NextBallTicketAccessor<INextBall1TicketService, NextBall1Round, NextBall1Bet, NextBall1BetLog>
    {
        public NextBall1TicketAccessor(INextBall1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class NextBall2TicketAccessor : NextBallTicketAccessor<INextBall2TicketService, NextBall2Round, NextBall2Bet, NextBall2BetLog>
    {
        public NextBall2TicketAccessor(INextBall2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}