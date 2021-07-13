using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class VipSeDieTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public VipSeDieTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<VipSeDieRound, VipSeDieBet>(request.RoundId, request.MemberId, request.FreeBet);

            return new VipSeDieTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<VipSeDieRound, VipSeDieRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}