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
    public class SicBoTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public SicBoTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SicBoRound, SicBoOne, SicBoBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new SicBoTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<SicBoRound, SicBoRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneOffset)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                TotalBetWin = result.Item3?.Betwin ?? 0
            };
        }
    }
}