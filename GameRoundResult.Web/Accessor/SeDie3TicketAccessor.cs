using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class SeDie3TicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public SeDie3TicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<SeDie3Round, SeDie3Bet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new SeDie3TicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<SeDie3Round, SeDie3RoundResultViewModel>(mapper, request.TimeZoneOffset),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneOffset),
                Odds = result.Item2?.Odds,
                Rate = result.Item2?.Rate ?? 0,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2?.Currency, request.OperatorId),
            };
        }
    }
}
