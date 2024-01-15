namespace GameRoundResult.Core.Database.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using GameRoundResult.Core._Share;
    using GameRoundResult.Core.Database.Entities;
    using GameRoundResult.Core.Extensions;
    using MongoDB.Driver;

    public interface ICascadingSlotBetRepository
    {
        Task<(BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity)> GetAsync(long roundId, string playerId, string operatorId, string gameName);

        Task<BaseCascadingSlotRoundEntity> GetEndRoundAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class CascadingSlotBetRepository : GameBetRepository, ICascadingSlotBetRepository
    {
        public CascadingSlotBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity)> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        {
            var round = await GetRoundCollection<BaseCascadingSlotRoundEntity>(gameName)
               .Find(x => x.RoundId == roundId && x.PlayerId == playerId && x.OperatorId == operatorId)
               .FirstOrDefaultAsync();

            if (round != null)
            {
                var totalMultipliers = GetMultiplierCollection<BaseCascadingSlotTotalMultiplierEntity>(gameName)
               .Find(x => x.PlayerId == playerId).ToList();

                if (totalMultipliers.Count > 0)
                {
                    var totalMultiplier = totalMultipliers.FirstOrDefault(e => e.Rounds.Any(x => x.RoundId == roundId));
                    return (round, totalMultiplier);
                }
            }

            return (round, null);
        }

        public Task<BaseCascadingSlotRoundEntity> GetEndRoundAsync(long roundId, string playerId, string operatorId, string gameName)
            => GetRoundCollection<BaseCascadingSlotRoundEntity>(gameName)
                .Find(EndRoundFilter(roundId, playerId, operatorId))
                .FirstOrDefaultAsync();

        private static Expression<Func<BaseCascadingSlotRoundEntity, bool>> EndRoundFilter(long roundId, string playerId, string operatorId)
            => DefaultFilter(roundId, playerId, operatorId);

        private static Expression<Func<BaseCascadingSlotRoundEntity, bool>> DefaultFilter(long roundId, string playerId, string operatorId)
        {
            Expression<Func<BaseCascadingSlotRoundEntity, bool>> defaultExpression = bet =>
                  bet.PlayerId == playerId
                  && bet.RoundId == roundId
                  && bet.OperatorId == operatorId;

            return defaultExpression;
        }

        private IMongoCollection<T> GetMultiplierCollection<T>(string name) where T : BaseCascadingSlotTotalMultiplierEntity
            => database.GetCollection<T>(CollectionNameFormatter.CascadingSlotMultiplier(name));
    }
}