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

        Task<(long, IEnumerable<SeDieRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<FishPrawnCrabRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

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

        Task<(long, IEnumerable<RouletteRound>)> GetRouletteRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<VipSeDieRound>)> GetVipSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<SpecialSeDieRound>)> GetSpecialSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<VipFishPrawnCrabRound>)> GetVipFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameRoundCollections.BigSmallRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BigSmallRound>(date, roundId, MiniGameRoundCollections.BigSmallTurboRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameRoundCollections.OddEvenTurboRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<OddEvenRound>(date, roundId, MiniGameRoundCollections.OddEvenRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<SeDieRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<SeDieRound>(date, roundId, MiniGameRoundCollections.SeDieRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<FishPrawnCrabRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<FishPrawnCrabRound>(date, roundId, MiniGameRoundCollections.FishPrawnRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<DragonTigerRound>(date, roundId, MiniGameRoundCollections.DragonTigerRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoProMaxRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<MiniSeDieRound>(date, roundId, MiniGameRoundCollections.MiniSeDieRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoProVietRound, page, pageSize, x => x.Result != null && x.SettlementResult != null);
        }

        public async Task<(long, IEnumerable<BaccaratRound>)> GetBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<BaccaratRound>(date, roundId, MiniGameRoundCollections.BaccaratRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoMaxRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMax2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoMax2Round, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMiniRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoMiniRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMini2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoMini2Round, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoEastRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoEastRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoWestRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoWestRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoSouthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoSouthRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoNorthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<KenoRound>(date, roundId, MiniGameRoundCollections.KenoNorthRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<VipSeDieRound>)> GetVipSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<VipSeDieRound>(date, roundId, MiniGameRoundCollections.VipSeDieRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<SpecialSeDieRound>)> GetSpecialSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<SpecialSeDieRound>(date, roundId, MiniGameRoundCollections.SpecialSeDieRound, page, pageSize);
        }

        public async Task<(long, IEnumerable<VipFishPrawnCrabRound>)> GetVipFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<VipFishPrawnCrabRound>(date, roundId, MiniGameRoundCollections.VipFishPrawnCrabRound, page, pageSize);
        }

        private async Task<(long, IEnumerable<T>)> GetRoundResultAsync<T>(DateTime date, long roundId, string roundCollectionName, int page, int pageSize
            , Expression<Func<T, bool>> filter = null) where T : GameRound
        {
            var collection = database.GetCollection<T>(roundCollectionName);
            var fromDate = date;
            var toDate = fromDate.AddDays(1);

            Expression<Func<T, bool>> defaultExpression = x => (roundId == 0 && x.Time >= fromDate && x.Time < toDate) || x.Round == roundId;

            var finalExpression = filter != null ? defaultExpression.And<T>(filter) : defaultExpression;

            var cursor = collection.Find(finalExpression);

            var total = await cursor.CountDocumentsAsync();
            var data = await cursor.SortByDescending(x => x.Time).Skip(page).Limit(pageSize).ToListAsync();
            return (total, data);
        }

        public async Task<(long, IEnumerable<RouletteRound>)> GetRouletteRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await GetRoundResultAsync<RouletteRound>(date, roundId, MiniGameRoundCollections.RouletteRound, page, pageSize);
        }
    }
}