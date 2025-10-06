﻿using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;
using GameRoundResult.Web.Models.GameTicket;
using System.Linq;
using GameRoundResult.Core.Database.Entities.CoinMining;

namespace GameRoundResult.Web.Accessor
{
    public class GoldAndDragonAccessor<TOneEntity, TBetEntity> : IGameTicketAccessor
        where TOneEntity : GoldAndDragonRound
        where TBetEntity : GoldAndDragonBetLog

    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public GoldAndDragonAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetCascadingClusterBetAsync<TOneEntity, TBetEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameConfigs.Name);

            var viewModel = new GoldAndDragonTicketViewModel();

            if (result.Item1 != null)
            {
                viewModel.Bet = result.Item1;
                viewModel.TimeZoneOffset = request.TimeZoneOffset;
                viewModel.GameType = request.GameConfigs.Type;
                
                // Process symbols data if available
                if (result.Item1.SettlementResult?.Tumbles != null)
                {
                    viewModel.HasSymbolData = result.Item1.SettlementResult.Tumbles.Any(t => t.Symbols != null && t.Symbols.Any());
                }
            }

            return viewModel;
        }

    }
}
