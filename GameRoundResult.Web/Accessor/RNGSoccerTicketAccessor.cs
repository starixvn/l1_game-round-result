using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Database.Entities.RNGSoccer;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class RNGSoccerTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public RNGSoccerTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<RNGSoccerRound, RNGSoccerBet, RNGSoccerBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId); 

            var viewModel = new RNGSoccerTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<RNGSoccerRound, RNGSoccerRoundResultViewModel>(mapper, request.TimeZoneOffset),
                BetLogs = result.Item2?.Select(x => x.ToBetLogViewModel<RNGSoccerBetLog, RNGSoccerBetLogViewModel>(mapper, request.TimeZoneOffset)),
                Odds = result.Item3?.Odds,
                TotalBet = result.Item3?.Sum ?? 0,
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
