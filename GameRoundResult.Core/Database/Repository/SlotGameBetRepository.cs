using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISlotGameBetRepository
    {
        Task<T> GetAsync<T>(long roundId, int playerId, string operatorId, string gameName) where T : BaseSlotRoundEntity;

        Task<T> GetEndRoundAsync<T>(long roundId, int playerId, string operatorId, string gameName, string siteId) where T : BaseSlotRoundEntity;
    }

    public class SlotGameBetRepository : GameBetRepository, ISlotGameBetRepository
    {
        public SlotGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public Task<T> GetAsync<T>(long roundId, int playerId, string operatorId, string gameName) where T : BaseSlotRoundEntity
        => GetRoundCollection<T>(gameName)
               .Find(RoundFilter<T>(roundId, playerId, operatorId))
               .FirstOrDefaultAsync();

        public Task<T> GetEndRoundAsync<T>(long roundId, int playerId, string operatorId, string gameName, string siteId) where T : BaseSlotRoundEntity
        => GetRoundCollection<T>(gameName)
               .Find(EndRoundFilter<T>(roundId, playerId, operatorId, siteId))
               .FirstOrDefaultAsync();

        private static Expression<Func<T, bool>> EndRoundFilter<T>(long roundId, int playerId, string operatorId, string siteId) where T : BaseSlotRoundEntity
        {
            Expression<Func<T, bool>> defaultExpression = DefaultFilter<T>(roundId, playerId, operatorId);

            return defaultExpression.And(bet => bet.SiteId == siteId);
        }

        private static Expression<Func<T, bool>> RoundFilter<T>(long roundId, int playerId, string operatorId) where T : BaseSlotRoundEntity
        {
            Expression<Func<T, bool>> defaultExpression = DefaultFilter<T>(roundId, playerId, operatorId);

            return defaultExpression.And(bet => bet.Paid);
        }

        private static Expression<Func<T, bool>> DefaultFilter<T>(long roundId, int playerId, string operatorId) where T : BaseSlotRoundEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
                  bet.PlayerId == playerId
                  && bet.RoundId == roundId
                  && bet.OperatorId == operatorId;

            return defaultExpression;
        }
    }
}