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
    public class KenoMatchTicketAccessor<TRoundEntity, TOneEntity, TBetEntity> : IGameTicketAccessor
        where TRoundEntity : KenoMatchRound
        where TOneEntity : KenoMatchOne
        where TBetEntity : KenoMatchBet 
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public KenoMatchTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(request.RoundId, request.MemberId, request.FreeBet);

            return new KenoMatchTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRoundEntity, KenoMatchRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                TotalBet = result.Item3?.TotalAmount ?? 0,
                TotalBetWin = result.Item3?.Betwin ?? 0
            };
        }
    }
}