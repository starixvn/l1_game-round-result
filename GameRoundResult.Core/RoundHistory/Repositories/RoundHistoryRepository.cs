using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Core.Extensions;
using GameRoundResult.Core.Models.RoundHistory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Repository.RoundHistory
{
    public interface IRoundHistoryRepository 
    {
        Task<TRoundEntity> GetRoundAsync<TRoundEntity>(long roundId, FilterDefinition<TRoundEntity> baseFilterExpression) where TRoundEntity : GameRound;

        Task<IEnumerable<TBetEntity>> GetBetsAsync<TBetEntity>(RoundHistoryRequestBase filter, FilterDefinition<TBetEntity> baseFilterExpression)
            where TBetEntity : RoundHistoryBetEntity, new();
    }

    public class RoundHistoryRepository : IRoundHistoryRepository
    {
        protected readonly IMongoDatabase database;
        public RoundHistoryRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task<TRoundEntity> GetRoundAsync<TRoundEntity>(long roundId, FilterDefinition<TRoundEntity> baseFilterExpression) where TRoundEntity : GameRound
            =>  await database.GetCollection<TRoundEntity>(Document.GetCollectionName(typeof(TRoundEntity))).Find(baseFilterExpression).FirstOrDefaultAsync();       

        public async Task<IEnumerable<TBetEntity>> GetBetsAsync<TBetEntity>(RoundHistoryRequestBase filter, FilterDefinition<TBetEntity> baseFilterExpression)
            where TBetEntity : RoundHistoryBetEntity, new()
        {
            var betCollection = database.GetCollection<TBetEntity>(Document.GetCollectionName(typeof(TBetEntity)));
            var expression = GetExpression<TBetEntity>(baseFilterExpression, filter.RoundId, filter.Nickname, filter.ExcludeUUS, filter.PartnerId);
            var bets = await betCollection.Find(expression).SortBy(x => x.Id).ToListAsync();

            return bets;
        }

        protected virtual FilterDefinition<TBetEntity> GetExpression<TBetEntity>(
            FilterDefinition<TBetEntity> baseFilterExpression,
            long roundId,
            string nickname,            
            bool excludeUUS = false,
            string partnerId = null) where TBetEntity : RoundHistoryBetEntity
        {
            var filter = baseFilterExpression;

            if (!string.IsNullOrWhiteSpace(nickname))
            {
                filter &= Builders<TBetEntity>.Filter.Regex(x => x.Name, new Regex($"(?i){nickname}"));
            }
            
            if (!string.IsNullOrEmpty(partnerId))
            {
                filter &= Builders<TBetEntity>.Filter.Eq(x => x.OperatorId, partnerId);
            }

            if (excludeUUS)
            {
                filter &= Builders<TBetEntity>.Filter.Ne(x => x.Currency, "UUS");
            }

            return filter;
        }
    }
}
