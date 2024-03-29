using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int gameType, int page, int pageSize) where GR : GameRound;

        Task<(long, IEnumerable<GD>)> GetGameDrawResultAsync<GD, R, S>(DateTime date, long drawId, int gameType, int page, int pageSize) 
            where GD : GameDraw<R, S>
            where R : GameDrawBase
            where S : GameDrawBase;
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

        public async Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int gameType, int page, int pageSize) where GR : GameRound
        {
            var gameInfo = await generalGameConfigRepository.GetConfigById(gameType);

            if(gameInfo != null && gameInfo.Type == (byte)GameConfigsType.Crash)
            {
                return await repository.GetCrashGameRoundResultAsync<GR>(date, roundId, gameInfo.DisplayName, page, pageSize);
            }

            return await repository.GetGameRoundResultAsync<GR>(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<GD>)> GetGameDrawResultAsync<GD, R, S>(DateTime date, long drawId, int gameType, int page, int pageSize)
            where GD : GameDraw<R,S>
            where R : GameDrawBase
            where S : GameDrawBase
        {
            return await repository.GetDrawResultAsync<GD, R, S>(date, drawId, page, pageSize);
        }
    }
}