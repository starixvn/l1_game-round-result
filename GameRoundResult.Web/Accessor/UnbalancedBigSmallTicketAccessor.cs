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
#pragma warning disable S2436 // Types and methods should not have too many generic parameters
    public class UnbalancedBigSmallTicketAccessor<TRoundEntity, TBetEntity, TBetLogEntity> : IGameTicketAccessor
#pragma warning restore S2436 // Types and methods should not have too many generic parameters
        where TRoundEntity : UnbalancedBigSmallRound
        where TBetEntity : UnbalancedBigSmallBet
        where TBetLogEntity : UnbalancedBigSmallBetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public UnbalancedBigSmallTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var bigSmallResult = await gameBetService.GetAsync<TRoundEntity, TBetEntity, TBetLogEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new UnbalancedBigSmallTicketViewModel
            {
                RoundResult = bigSmallResult.Item1?.ToViewModel<TRoundEntity, BigSmallRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = bigSmallResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneOffset)),
                TotalBetAmount = bigSmallResult.Item3?.TotalAmount ?? 0,
                TotalBetWin = bigSmallResult.Item3?.Betwin ?? 0,
            };
        }
    }
}