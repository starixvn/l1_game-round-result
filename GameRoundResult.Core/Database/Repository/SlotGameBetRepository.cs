using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISlotGameBetRepository
    {
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName);

        Task<SlotGameRound> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName, string siteId);
    }

    public class SlotGameBetRepository : GameBetRepository, ISlotGameBetRepository
    {
        public SlotGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName)
        => GetCollection(gameName)
               .Find(RoundFilter<SlotGameRound>(roundId, playerId, operatorId))
               .FirstOrDefaultAsync();

        public Task<SlotGameRound> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName, string siteId)
        => GetCollection(gameName)
               .Find(EndRoundFilter<SlotGameRound>(roundId, playerId, operatorId, siteId))
               .FirstOrDefaultAsync();

        private IMongoCollection<SlotGameRound> GetCollection(string name) => database.GetCollection<SlotGameRound>(CollectionNameFormatter.Round(name));

        private static Expression<Func<T, bool>> EndRoundFilter<T>(long roundId, int playerId, string operatorId, string siteId) where T : SlotGameRound
        {
            Expression<Func<T, bool>> defaultExpression = DefaultFilter<T>(roundId, playerId, operatorId);

            defaultExpression.And(bet => bet.SiteId == siteId);

            return defaultExpression;
        }

        private static Expression<Func<T, bool>> RoundFilter<T>(long roundId, int playerId, string operatorId) where T : SlotGameRound
        {
            Expression<Func<T, bool>> defaultExpression = DefaultFilter<T>(roundId, playerId, operatorId);

            defaultExpression.And(bet => bet.Paid);

            return defaultExpression;
        }

        private static Expression<Func<T, bool>> DefaultFilter<T>(long roundId, int playerId, string operatorId) where T : SlotGameRound
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
                  bet.PlayerId == playerId
                  && bet.RoundId == roundId
                  && bet.OperatorId == operatorId;

            return defaultExpression;
        }
    }
}