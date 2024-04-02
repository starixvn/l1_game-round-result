using AutoMapper;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class LuckyNextTicketAccessor<ITicketService, Draw, Bets, BetLogs> : IGameTicketAccessor
        where ITicketService : IDrawTicketService<Draw, Bets, BetLogs, LuckyNextRoundResult, LuckyNextSettlementResult>
        where Draw : LuckyNext1Round
        where Bets : LuckyNext1Bet
        where BetLogs : LuckyNext1BetLog
    {
        private readonly ITicketService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public LuckyNextTicketAccessor(ITicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            var viewModel = new LuckyNextTicketViewModel
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

    public class LuckyNext1TicketAccessor : LuckyNextTicketAccessor<ILuckyNext1TicketService, LuckyNext1Round, LuckyNext1Bet, LuckyNext1BetLog>
    {
        public LuckyNext1TicketAccessor(ILuckyNext1TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
    public class LuckyNext2TicketAccessor : LuckyNextTicketAccessor<ILuckyNext2TicketService, LuckyNext2Round, LuckyNext2Bet, LuckyNext2BetLog>
    {
        public LuckyNext2TicketAccessor(ILuckyNext2TicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
            : base(gameBetService, mapper, currencyGroupService) { }
    }
}