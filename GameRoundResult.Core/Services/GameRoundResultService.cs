using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int gameType, int page, int pageSize) where GR : GameRound;

        Task<(long, IEnumerable<BacBallRound>)> GetBacBallRoundResultAsync(DateTime date, long roundId, int gameType, int page, int pageSize);
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;
        private readonly IGeneralGameSettingRepository generalGameConfigRepository;

        public GameRoundResultService(IGameRoundRepository repository, IGeneralGameSettingRepository generalGameConfigRepository)
        {
            this.repository = repository;
            this.generalGameConfigRepository = generalGameConfigRepository;
        }

        public async Task<(long, IEnumerable<BacBallRound>)> GetBacBallRoundResultAsync(DateTime date, long roundId, int gameType, int page, int pageSize) 
        {
            return await repository.GetBacBallRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int gameType, int page, int pageSize) where GR : GameRound
        {
            var gameInfo = await generalGameConfigRepository.GetConfigById(gameType);

            if(gameInfo != null && gameInfo.Type == (byte)GameConfigsType.Crash)
            {
                return await repository.GetCrashGameRoundResultAsync<GR>(date, roundId, gameInfo.DisplayName, page, pageSize);
            }

            return await repository.GetGameRoundResultAsync<GR>(date, roundId, page, pageSize);
        }
    }
}