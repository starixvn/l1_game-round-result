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
    public class RouletteTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public RouletteTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request, GameConfigModel gameConfigs)
        {
            var result = await gameBetService.GetAsync<RouletteRound, RouletteOne, RouletteBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new RouletteTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<RouletteRound, RouletteRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
            };
        }
    }
}