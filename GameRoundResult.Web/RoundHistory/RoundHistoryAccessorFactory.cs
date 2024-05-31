using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.RoundHistory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.RoundHistory
{
    public interface IRoundHistoryAccessorFactory
    {
        IRoundHistoryAccessor GetService(GameType game);
    }

    public class RoundHistoryAccessorFactory : IRoundHistoryAccessorFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.CoinToss, typeof(RoundHistoryAccessor<CoinTossRound, CoinTossRoundResultViewModel, CoinTossBet, RoundHistoryBetViewModel>) },
            { GameType.FootballCoinToss, typeof(RoundHistoryAccessor<FootballCoinTossRound, FootballCoinTossRoundResultViewModel, FootballCoinTossBet, RoundHistoryBetViewModel>) },
            { GameType.Bac81, typeof(RoundHistoryAccessor<Bac81Round, BaccaratXRoundResultViewModel, Bac81Bet, RoundHistoryBetViewModel>) },
        };

        private readonly IServiceProvider serviceProvider;

        public RoundHistoryAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IRoundHistoryAccessor GetService(GameType game)
        {
            return (IRoundHistoryAccessor)serviceProvider.GetRequiredService(services[game]);
        }
    }
}
