using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameRoundRepository
    {
        Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int page, int pageSize, Expression<Func<GR, bool>> filter = null) where GR : GameRound;

        Task<(long, IEnumerable<GR>)> GetCrashGameRoundResultAsync<GR>(DateTime date, long roundId, string displayName, int page, int pageSize) where GR : GameRound;
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        private async Task<(long, IEnumerable<T>)> GetRoundResultAsync<T>(
            DateTime date,
            long roundId,
            string roundCollectionName,
            int page,
            int pageSize,
            Expression<Func<T, bool>> filter = null) where T : GameRound
        {
            var fromDate = date;
            var toDate = fromDate.AddDays(1);

            Expression<Func<T, bool>> defaultExpression = x => (roundId == 0 && x.Time >= fromDate && x.Time < toDate) || x.RoundId == roundId;

            var finalExpression = filter != null ? defaultExpression.And(filter) : defaultExpression;

            var cursor = database.GetCollection<T>(roundCollectionName).Find(finalExpression);

            var total = await cursor.CountDocumentsAsync();
            var data = await cursor.SortByDescending(x => x.Id).Skip(page).Limit(pageSize).ToListAsync();

            return (total, data);
        }

        public async Task<(long, IEnumerable<GR>)> GetGameRoundResultAsync<GR>(DateTime date, long roundId, int page, int pageSize, Expression<Func<GR, bool>> filter = null) where GR : GameRound
        {
           
             var   collectionName = Document.GetCollectionName(typeof(GR));
           
            return string.IsNullOrWhiteSpace(collectionName)
                ? throw new InvalidOperationException(nameof(collectionName))
                : await GetRoundResultAsync<GR>(date, roundId, collectionName, page, pageSize, filter);
        }

        public async Task<(long, IEnumerable<GR>)> GetCrashGameRoundResultAsync<GR>(DateTime date, long roundId, string displayName, int page, int pageSize) where GR : GameRound
        {
            var collectionName = CollectionNameFormatter.Round(displayName);
         
            return string.IsNullOrWhiteSpace(collectionName)
                ? throw new InvalidOperationException(nameof(collectionName))
                : await GetRoundResultAsync<GR>(date, roundId, collectionName, page, pageSize);
        }
    }
}