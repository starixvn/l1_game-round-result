using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<IEnumerable<GameRound>> GetRoundResultAsync(byte gameTypeId, DateTime date);
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public GameRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GameRound>> GetRoundResultAsync(byte gameTypeId, DateTime date)
        {
            switch (gameTypeId)
            {
                case GameType.BigSmall:
                    return await repository.GetBigSmallRoundResultAsync(date);

                case GameType.BigSmallTurbo:
                    return await repository.GetBigSmallTurboRoundResultAsync(date);

                default:
                    throw new ArgumentException(nameof(gameTypeId));
            }
        }
    }
}