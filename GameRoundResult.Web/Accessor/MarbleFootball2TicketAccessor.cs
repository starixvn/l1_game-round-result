using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class MarbleFootball2TicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;        

        public MarbleFootball2TicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<MarbleFootball2Round, MarbleFootball2Bet, MarbleFootball2BetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            var viewModel = new MarbleFootball2TicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<MarbleFootball2Round, MarbleFootball2RoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<MarbleFootball2BetLog, MarbleFootball2BetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                TotalBet = result.Item3?.TotalAmount ?? 0,
                BetWin = result.Item3?.Betwin ?? 0
            };
            if (result.Item2.Any())
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.First().Currency, request.OperatorId);
            }
            return viewModel;
        }
    }
}