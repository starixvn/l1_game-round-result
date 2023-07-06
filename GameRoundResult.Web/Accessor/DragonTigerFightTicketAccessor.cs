using AutoMapper;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class DragonTigerFightTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;        

        public DragonTigerFightTicketAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<DragonTigerFightRound, DragonTigerFightOne, DragonTigerFightBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            var viewModel = new DragonTigerFightTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<DragonTigerFightRound, DragonTigerFightRoundResultViewModel>(mapper, request.TimeZoneInfo),
                BetLogs = result.Item2?.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                Odds = result.Item3?.Odds,
                TotalBet = result.Item3?.TotalBet ?? 0,
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