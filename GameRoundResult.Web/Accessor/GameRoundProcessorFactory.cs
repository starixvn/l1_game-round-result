using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameRoundAccessorFactory
    {
        IGameRoundAccessor GetService(GameType game);
    }

    public class GameRoundAccessorFactory : IGameRoundAccessorFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.BigSmall, typeof(GameRoundAccessor<BigSmallRound, BigSmallRoundResultViewModel>) },
            { GameType.BigSmallTurbo, typeof(GameRoundAccessor<TurboBigSmallRound, BigSmallRoundResultViewModel>) },
        };

        private readonly IServiceProvider serviceProvider;

        public GameRoundAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameRoundAccessor GetService(GameType game)
        => (IGameRoundAccessor)serviceProvider.GetRequiredService(services[game]);
    }
}