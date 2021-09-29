using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class FourGuardiansTicketAccessor<SlotRound> : IGameTicketAccessor
        where SlotRound : FourGuardiansRound
    {
        private readonly IFourGuardiansTicketService gameBetService;
        private readonly IMapper mapper;

        public FourGuardiansTicketAccessor(IFourGuardiansTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SlotRound>(request.RoundId, request.MemberId);

            return new FourGuardiansTicketViewModel
            {
                RoundResult = result?.ToViewModel<SlotRound, FourGuardiansRoundResultViewModel>(mapper, request.TimeZoneInfo),
            };
        }
    }
}