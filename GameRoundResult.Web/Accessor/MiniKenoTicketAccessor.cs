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
    public class MiniKenoTicketAccessor<TKenoRound, TKenoOne, TKenoBet> : IGameTicketAccessor
        where TKenoRound : KenoRound
        where TKenoOne : RNGKenoOnes
        where TKenoBet : RNGKenoBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public MiniKenoTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TKenoRound, TKenoOne, TKenoBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new RNGKenoTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TKenoRound, KenoRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                TotalWin = result.Item3?.Betwin ?? 0
            };
        }
    }
}