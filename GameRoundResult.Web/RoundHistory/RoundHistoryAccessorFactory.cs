using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities.BacBall;
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
            { GameType.BacBall1, typeof(DrawRoundHistoryAccessor<BacBall1Round, BacBallRoundResultViewModel, BacBall1Bet, RoundHistoryBetViewModel, BacBallRoundResult, BacBallSettlementResult>) },
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
