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

    public class FootballSlotTicketAccessor<TRound, TBet, TBetLog> : IGameTicketAccessor
#pragma warning restore S2436 // Types and methods should not have too many generic parameters
        where TRound : FootballSlotRound
        where TBet : FootballSlotBet
        where TBetLog : FootballSlotBetLog
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public FootballSlotTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRound, TBet, TBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new FootballSlotTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TRound, FootballSlotRoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0
            };
        }
    }
}