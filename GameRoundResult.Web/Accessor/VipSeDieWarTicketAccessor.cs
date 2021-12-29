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
    public class VipSeDieWarTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public VipSeDieWarTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<VipSeDieWarRound, VipSeDieWarOne, VipSeDieWarBet>(request.RoundId, request.MemberId, request.FreeBet, request.PartnerId);

            return new VipSeDieWarTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<VipSeDieWarRound, VipSeDieWarRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                TotalBetWin = result.Item3?.Betwin ?? 0
            };
        }
    }
}