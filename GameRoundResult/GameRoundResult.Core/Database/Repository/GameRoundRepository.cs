using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameRoundRepository
    {
        Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<DragonTigerRound>> GetDragonTigerRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<KenoProMaxRound>> GetKenoProMaxRoundResultAsync(DateTime date, long roundId);
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase("minigame");
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameCollections.BigSmallRound);
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameCollections.BigSmallTurboRound);
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameCollections.OddEvenTurboRound);
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameCollections.OddEvenRound);
        }

        public async Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<ShakeThePlateRound>(date, roundId, MiniGameCollections.ShakeThePlateRound);
        }

        public async Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<FishPrawnRound>(date, roundId, MiniGameCollections.FishPrawnRound);
        }

        public async Task<IEnumerable<DragonTigerRound>> GetDragonTigerRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<DragonTigerRound>(date, roundId, MiniGameCollections.DragonTigerRound);
        }

        public async Task<IEnumerable<KenoProMaxRound>> GetKenoProMaxRoundResultAsync(DateTime date, long roundId)
        {
            return await GetRoundResultAsync<KenoProMaxRound>(date, roundId, MiniGameCollections.KenoProMaxRound);
        }

        private async Task<IEnumerable<T>> GetRoundResultAsync<T>(DateTime date, long roundId, string roundCollectionName) where T : GameRound
        {
            var collection = database.GetCollection<T>(roundCollectionName);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }
    }
}