using System;
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
    public class SoccerPinGoalTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public SoccerPinGoalTicketAccessor(
            IGameBetService gameBetService,
            IMapper mapper,
            ICurrencyGroupService currencyGroupService
        )
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<
                SoccerPinGoalRound,
                SoccerPinGoalBet,
                SoccerPinGoalBetLog
            >(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            var viewModel = new SoccerPinGoalTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<
                    SoccerPinGoalRound,
                    SoccerPinGoalRoundResultViewModel
                >(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x =>
                    x.ToBetLogViewModel<SoccerPinGoalBetLog, SoccerPinGoalBetLogViewModel>(
                        mapper,
                        request.TimeZoneOffset
                    )
                ),
                Odds = result.Item3?.Odds,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0,
            };
            if (result.Item2.Any())
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(
                    result.Item2.First().Currency,
                    request.OperatorId
                );
            }
            return viewModel;
        }
    }
}
