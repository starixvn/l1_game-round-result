using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class SeDieTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public SeDieTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SeDieRound, SeDieBet>(request.RoundId, request.MemberId, request.FreeBet);

            return new SeDieTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<SeDieRound, SeDieRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}