using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int page, int pageSize) where GR : GameRound;
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public GameRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int page, int pageSize) where GR : GameRound
        {
            return await repository.GetGameRoundResultAsync<GR>(date, roundId, page, pageSize);
        }
    }
}