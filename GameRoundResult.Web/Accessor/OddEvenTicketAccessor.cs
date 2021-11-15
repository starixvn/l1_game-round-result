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
    public class OddEvenTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public OddEvenTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TurboOddEvenRound, OddEvenOne, OddEvenBet>(request.RoundId, request.MemberId, request.FreeBet);

            return new OddEvenTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TurboOddEvenRound, OddEvenRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
            };
        }
    }
}