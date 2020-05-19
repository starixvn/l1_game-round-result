using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<DragonTigerRound>> GetDragonTigerRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<KenoProMaxRound>> GetKenoProMaxRoundResultAsync(DateTime date, long roundId)
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public GameRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetBigSmallRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetBigSmallTurboRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<DragonTigerRound>> GetDragonTigerRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetDragonTigerRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetFishPrawnRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<KenoProMaxRound>> GetKenoProMaxRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetKenoProMaxRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetOddEvenRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetOddEvenTurboRoundResultAsync(date, roundId);
        }

        public async Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId)
        {
            return await repository.GetShakeThePlateRoundResultAsync(date, roundId);
        }
    }
}