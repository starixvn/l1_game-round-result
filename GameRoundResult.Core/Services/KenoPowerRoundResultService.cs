using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IKenoPowerRoundResultService
    {
        Task<(long, IEnumerable<TRoundEntity>)> GetGameRoundResultAsync<TRoundEntity>(DateTime date, long roundId, int page, int pageSize)
            where TRoundEntity : KenoPowerRound;
    }

    public class KenoPowerRoundResultService : IKenoPowerRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public KenoPowerRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(long, IEnumerable<TRoundEntity>)> GetGameRoundResultAsync<TRoundEntity>(DateTime date, long roundId, int page, int pageSize)
            where TRoundEntity : KenoPowerRound
        {
            return await repository.GetGameRoundResultAsync<TRoundEntity>(date, roundId, page, pageSize, x => x.Settled);
        }
    }
}