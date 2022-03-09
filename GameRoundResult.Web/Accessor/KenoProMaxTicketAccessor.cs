using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class KenoProMaxTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public KenoProMaxTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<KenoProMaxRound, KenoProMaxBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new KenoProMaxTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<KenoProMaxRound, KenoRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}