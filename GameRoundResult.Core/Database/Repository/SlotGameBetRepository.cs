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
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName, bool paid = true);

        Task<SlotGameRound> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName, string siteId);
    }

    public class SlotGameBetRepository : GameBetRepository, ISlotGameBetRepository
    {
        public static readonly string CollectionSuffix = "_rounds";

        public SlotGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName, bool paid = true)
        => GetCollection(gameName)
               .Find(RoundFilter<SlotGameRound>(roundId, playerId, operatorId, paid))
               .FirstOrDefaultAsync();

        public Task<SlotGameRound> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName, string siteId)
        => GetCollection(gameName)
               .Find(EndRoundFilter<SlotGameRound>(roundId, playerId, operatorId, siteId))
               .FirstOrDefaultAsync();

        private IMongoCollection<SlotGameRound> GetCollection(string name) => database.GetCollection<SlotGameRound>(CollectionNameFormatter.RoundName(name));

        private static Expression<Func<T, bool>> EndRoundFilter<T>(long roundId, int playerId, string operatorId, string siteId) where T : SlotGameRound
        {
            Expression<Func<T, bool>> defaultExpression = RoundFilter<T>(roundId, playerId, operatorId, false);

            defaultExpression.And(round => round.SiteId == siteId);

            return defaultExpression;
        }

        private static Expression<Func<T, bool>> RoundFilter<T>(long roundId, int playerId, string operatorId, bool paid) where T : SlotGameRound
        {
            Expression<Func<T, bool>> defaultExpression = bet =>
                  bet.PlayerId == playerId
                  && bet.RoundId == roundId
                  && bet.OperatorId == operatorId
                  && bet.Paid == paid;

            return defaultExpression;
        }
    }
}