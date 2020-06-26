using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
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

        Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<BaccaratRound>)> GetBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMax2RoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMiniRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMini2RoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoEastRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoWestRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoSouthRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoNorthRoundResultAsync(DateTime date, long roundId, int page, int pageSize);
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

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoProMaxRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<MiniSeDieRound>(date, roundId, MiniGameCollections.MiniSeDieRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoProVietRound, page, pageSize, x => x.Result != null && x.SettlementResult != null);
        }

        public async Task<(long, IEnumerable<BaccaratRound>)> GetBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BaccaratRound>(date, roundId, MiniGameCollections.BaccaratRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoMaxRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMax2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoMax2Round, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMiniRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoMiniRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMini2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoMini2Round, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoEastRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoEastRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoWestRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoWestRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoSouthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoSouthRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoNorthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameCollections.KenoNorthRound, page, pageSize);
        }

        private async Task<(long, IEnumerable<T>)> GetRoundResultAsync<T>(DateTime date, long roundId, string roundCollectionName, int page, int pageSize
            , Expression<Func<T, bool>> filter = null) where T : GameRound
        {
            var collection = database.GetCollection<T>(roundCollectionName);
            var fromDate = date;
            var toDate = fromDate.AddDays(1);

            Expression<Func<T, bool>> defaultExpression = x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId);

            var finalExpression = filter != null ? defaultExpression.And<T>(filter) : defaultExpression;

            var cursor = collection.Find(finalExpression);

            var total = await cursor.CountDocumentsAsync();
            var data = await cursor.SortByDescending(x => x.Time).Skip(page).Limit(pageSize).ToListAsync();
            return (total, data);
        }
    }
}