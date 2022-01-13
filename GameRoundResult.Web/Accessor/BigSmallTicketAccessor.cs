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
    public class BigSmallTicketAccessor<TRoundEntity, TOneEntity, TBetEntity> : IGameTicketAccessor
        where TRoundEntity : BigSmallRound
        where TOneEntity : BigSmallOne
        where TBetEntity : BigSmallBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public BigSmallTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var bigSmallResult = await gameBetService.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(request.RoundId, request.MemberId, request.FreeBet, request.PartnerId);

            return new BigSmallTicketViewModel
            {
                RoundResult = bigSmallResult.Item1?.ToViewModel<TRoundEntity, BigSmallRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bets = bigSmallResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
            };
        }
    }
}