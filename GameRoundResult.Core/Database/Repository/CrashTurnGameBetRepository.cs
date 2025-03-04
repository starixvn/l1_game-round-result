using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ICrashTurnGameBetRepository
    {
        Task<(BaseCrashTurnRoundEntity, IEnumerable<BaseBetLogEntity>)> GetBetAsync(long roundId, string playerId, bool freeBet, string operatorId, string gameName);
        Task<BaseCrashTurnRoundEntity> GetEndRoundAsync(long roundId, string playerId, bool freeBet, string operatorId, string gameName);
    }

    public class CrashTurnGameBetRepository : GameBetRepository, ICrashTurnGameBetRepository
    {
        public CrashTurnGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public virtual async Task<(BaseCrashTurnRoundEntity, IEnumerable<BaseBetLogEntity>)> GetBetAsync(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
        {
            var one = (await GetCrashTurnRoundAsync<BaseCrashTurnRoundEntity>(roundId, playerId, freeBet, CollectionNameFormatter.Round(gameName), operatorId)).FirstOrDefault();
            var bets = await GetBetLogsAsync<BaseBetLogEntity>(roundId, playerId, CollectionNameFormatter.BetLog(gameName), operatorId);

            return (one, bets);
        }

        public async Task<BaseCrashTurnRoundEntity> GetEndRoundAsync(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
        {
            var round = (await GetCrashTurnRoundAsync<BaseCrashTurnRoundEntity>(roundId, playerId, freeBet, CollectionNameFormatter.Round(gameName), operatorId)).FirstOrDefault();

            return (round);
        }
    }
}