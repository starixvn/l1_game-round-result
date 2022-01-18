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
    public class HiLoTicketAccessor : IGameTicketAccessor
    {
        private readonly IHiLoTicketService gameBetService;
        private readonly IMapper mapper;

        public HiLoTicketAccessor(IHiLoTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var hiloResult = await gameBetService.GetAsync(request.RoundId, request.MemberId, request.PartnerId);

            return new HiLoTicketViewModel
            {
                RoundResult = hiloResult.Item1?.ToViewModel<HiLoRound, HiLoRoundResultViewModel>(mapper, request.TimeZoneInfo),
                BetLogs = hiloResult.Item2.Select(x => mapper.Map<HiLoBetLogViewModel>(x))
            };
        }
    }
}