using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IKenoMatchRoundResultService
    {
        Task<(long, IEnumerable<TRoundEntity>)> GetGameRoundResultAsync<TRoundEntity>(DateTime date, long roundId, int page, int pageSize)
            where TRoundEntity : KenoMatchRound;
    }

    public class KenoMatchRoundResultService : IKenoMatchRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public KenoMatchRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(long, IEnumerable<TRoundEntity>)> GetGameRoundResultAsync<TRoundEntity>(DateTime date, long roundId, int page, int pageSize)
            where TRoundEntity : KenoMatchRound
        {
            return await repository.GetGameRoundResultAsync<TRoundEntity>(date, roundId, page, pageSize, x => x.FullTime != null);
        }
    }
}