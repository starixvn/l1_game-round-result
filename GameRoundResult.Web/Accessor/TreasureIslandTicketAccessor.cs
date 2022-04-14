using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class TreasureIslandTicketAccessor : IGameTicketAccessor
    {
        private readonly ITreasureIslandTicketService gameBetService;
        private readonly IMapper mapper;

        public TreasureIslandTicketAccessor(ITreasureIslandTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.MemberId);

            return new TreasureIslandTicketViewModel
            {
                RoundResult = result?.ToViewModel<TreasureIslandRound, TreasureIslandRoundResultViewModel>(mapper, request.TimeZoneInfo),
            };
        }
    }
}