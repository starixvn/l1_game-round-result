using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<ShakeThePlateRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<FishPrawnRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize);
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public GameRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetBigSmallRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetBigSmallTurboRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetDragonTigerRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<FishPrawnRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetFishPrawnRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoProMaxRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetOddEvenRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetOddEvenTurboRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<ShakeThePlateRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetShakeThePlateRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetMiniSeDieRoundResultAsync(date, roundId, page, pageSize);

        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoProVietRoundResult(date, roundId, page, pageSize);
        }
    }
}