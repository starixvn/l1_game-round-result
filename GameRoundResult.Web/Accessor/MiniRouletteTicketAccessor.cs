using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class MiniRouletteTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public MiniRouletteTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<MiniRouletteRound, MiniRouletteBet, MiniRouletteBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new MiniRouletteTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<MiniRouletteRound, MiniRouletteRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneOffset)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
            };
        }
    }
}
