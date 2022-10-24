using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class MiniKenoTicketAccessor<TKenoRound, TKenoOne> : IGameTicketAccessor
        where TKenoRound : KenoRound
        where TKenoOne : RNGKenoOnes
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
            var result = await gameBetService.GetAsync<TKenoRound, TKenoOne>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new RNGKenoTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TKenoRound, KenoRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}