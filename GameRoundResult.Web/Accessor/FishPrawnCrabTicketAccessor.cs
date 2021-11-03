using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class FishPrawnCrabTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public FishPrawnCrabTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<FishPrawnCrabRound, FishPrawnCrabBet>(request.RoundId, request.MemberId, request.FreeBet);

            return new FishPrawnCrabTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}