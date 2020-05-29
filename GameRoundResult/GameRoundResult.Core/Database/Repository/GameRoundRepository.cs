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
        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<ShakeThePlateRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<FishPrawnRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoProMaxRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase("minigame");
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameCollections.BigSmallRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameCollections.BigSmallTurboRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameCollections.OddEvenTurboRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameCollections.OddEvenRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<ShakeThePlateRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<ShakeThePlateRound>(date, roundId, MiniGameCollections.ShakeThePlateRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<FishPrawnRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<FishPrawnRound>(date, roundId, MiniGameCollections.FishPrawnRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<DragonTigerRound>(date, roundId, MiniGameCollections.DragonTigerRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoProMaxRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoProMaxRound>(date, roundId, MiniGameCollections.KenoProMaxRound, page, pageSize);
        }

        private async Task<(long, IEnumerable<T>)> GetRoundResultAsync<T>(DateTime date, long roundId, string roundCollectionName, int page, int pageSize) where T : GameRound
        {
            var collection = database.GetCollection<T>(roundCollectionName);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            var cursor = collection.Find(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId));

            var total = await cursor.CountDocumentsAsync();
            var data = await cursor.SortByDescending(x => x.Time).Skip(page).Limit(pageSize).ToListAsync();
            return (total, data);
        }
    }
}