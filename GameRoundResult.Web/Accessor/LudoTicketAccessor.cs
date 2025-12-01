using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Accessor
{
    public class LudoTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public LudoTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<LudoRound, LudoBet, LudoBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return await CreateViewModelAsync(result, request.TimeZoneOffset, request.OperatorId);
        }

        private async Task<LudoTicketViewModel> CreateViewModelAsync(
            (LudoRound, IEnumerable<LudoBetLog>, LudoBet) result,
            TimeSpan timeZoneOffset,
            string operatorId)
        {
            if (result.Item1 == null || result.Item3 == null)
            {
                return new LudoTicketViewModel
                {
                    RoundResult = null,
                    BetLogs = new List<LudoBetLogViewModel>(),
                    Odds = null,
                    Rate = 0,
                    TotalBet = 0,
                    BetWin = 0,
                    ReachMaxWin = false,
                    FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item3?.Currency, operatorId),
                };
            }

            var betSummary = result.Item3;
            return new LudoTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<LudoRound, LudoRoundResultViewModel>(mapper, timeZoneOffset),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<LudoBetLog, LudoBetLogViewModel>(mapper, timeZoneOffset)),
                Odds = betSummary.Odds,
                Rate = betSummary.Rate,
                TotalBet = betSummary.TotalAmount,
                BetWin = betSummary.Betwin,
                ReachMaxWin = betSummary?.ReachMaxWin ?? false,
                FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(betSummary?.Currency, operatorId),
            };
        }
    }
}
