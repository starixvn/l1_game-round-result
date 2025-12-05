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
    public class Marbles158TicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;        

        public Marbles158TicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<Marbles158Round, Marbles158Bet, Marbles158BetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            var viewModel = new Marbles158TicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<Marbles158Round, Marbles158RoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<Marbles158BetLog, Marbles158BetLogViewModel>(mapper, request.TimeZoneOffset)),
                MarbleOdds = result.Item3?.MarbleOdds,
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