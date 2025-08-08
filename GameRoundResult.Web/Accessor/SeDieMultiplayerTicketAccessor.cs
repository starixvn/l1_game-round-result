using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities.SeDieMultiplayer;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class SeDieMultiplayerTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public SeDieMultiplayerTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SeDieMultiplayerRound, SeDieMultiplayerBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new SeDieMultiplayerTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<SeDieMultiplayerRound, SeDieMultiplayerRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneOffset)
            };
        }
    }
}
