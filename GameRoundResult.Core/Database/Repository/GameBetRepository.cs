using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.CoinMining;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameBetRepository
    {
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity;

        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;

        Task<(TOneEntity, IEnumerable<TBetEntity>)> GetBetAsync<TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
           where TOneEntity : BaseBetCoinMiningEntity
           where TBetEntity : BaseBetLogEntity;
    }

    public class GameBetRepository : IGameBetRepository
    {
        protected readonly IMongoDatabase database;

        public GameBetRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        protected async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, string playerId, bool freeBet, string collectionName, string operatorId,
            Expression<Func<T, bool>> filter = null) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
#pragma warning disable S1067 // Expressions should not be too complex
            bet.PlayerId == playerId
            && bet.RoundId == roundId
            && (!bet.FreeBet.HasValue || bet.FreeBet == freeBet)
            && bet.OperatorId == operatorId;
#pragma warning restore S1067 // Expressions should not be too complex
            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected async Task<IEnumerable<T>> GetBetsCoinmingAsync<T>(long roundId, string playerId, bool freeBet, string collectionName, string operatorId,
           Expression<Func<T, bool>> filter = null) where T : BaseBetCoinMiningEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
#pragma warning disable S1067 // Expressions should not be too complex
            bet.PlayerId == playerId
            && bet.RoundId == roundId
            && bet.Paid && (!bet.FreeBet.HasValue || bet.FreeBet == freeBet)
            && bet.OperatorId == operatorId;
#pragma warning restore S1067 // Expressions should not be too complex
            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected virtual async Task<IEnumerable<T>> GetBetLogsAsync<T>(long roundId, string playerId, string collectionName, string operatorId,
            Expression<Func<T, bool>> filter = null) where T : BaseBetLogEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
            bet.PlayerId == playerId 
            && bet.RoundId == roundId 
            && bet.OperatorId == operatorId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        protected async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
            => await database.GetCollection<T>(collectionName).Find(x => x.RoundId == roundId).FirstOrDefaultAsync();

        public virtual async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var one = (await GetBetsAsync<TOneEntity>(roundId, playerId, freeBet, Document.GetCollectionName(typeof(TOneEntity)), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<TBetEntity>(roundId, playerId, Document.GetCollectionName(typeof(TBetEntity)), operatorId);

            return (round, bets, one);
        }

        public virtual async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, Document.GetCollectionName(typeof(TRoundEntity)));
            var bet = (await GetBetsAsync<TBetEntity>(roundId, playerId, freeBet, Document.GetCollectionName(typeof(TBetEntity)), operatorId)).FirstOrDefault();

            return (round, bet);
        }

        public virtual async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, CollectionNameFormatter.Round(gameName));
            var one = (await GetBetsAsync<TOneEntity>(roundId, playerId, freeBet, CollectionNameFormatter.Bet(gameName), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<TBetEntity>(roundId, playerId, CollectionNameFormatter.BetLog(gameName), operatorId);

            return (round, bets, one);
        }

        public virtual async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            var round = await GetRoundAsync<TRoundEntity>(roundId, CollectionNameFormatter.Round(gameName));
            var bet = (await GetBetsAsync<TBetEntity>(roundId, playerId, freeBet, CollectionNameFormatter.Bet(gameName), operatorId)).FirstOrDefault();

            return (round, bet);
        }

        protected virtual IMongoCollection<T> GetRoundCollection<T>(string name) where T : GameRound
           => database.GetCollection<T>(CollectionNameFormatter.Round(name));

        public virtual async Task<(TOneEntity, IEnumerable<TBetEntity>)> GetBetAsync<TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TOneEntity : BaseBetCoinMiningEntity
            where TBetEntity : BaseBetLogEntity
        {
            var one = (await GetBetsCoinmingAsync<TOneEntity>(roundId, playerId, freeBet, CollectionNameFormatter.Round(gameName), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<TBetEntity>(roundId, playerId, CollectionNameFormatter.BetLog(gameName), operatorId);

            return (one, bets);
        }
    }
}