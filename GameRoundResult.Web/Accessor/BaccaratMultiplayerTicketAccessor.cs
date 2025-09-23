using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.SeDieMultiplayer;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class BaccaratMultiplayerTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public BaccaratMultiplayerTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<BaccaratMultiplayerRound, BaccaratMultiplayerBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new BaccaratMultiplayerTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<BaccaratMultiplayerRound, BaccaratMultiplayerRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneOffset),
                Rate = result.Item2?.Rate ?? 0,
                TotalBet = result.Item2?.TotalAmount ?? 0,
                BetWin = result.Item2?.Betwin ?? 0,
            };
        }
    }
}
