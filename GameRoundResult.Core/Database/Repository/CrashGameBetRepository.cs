using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ICrashGameBetRepository
    {
        Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, int playerId, string operatorId, string gameName);
        Task<(CrashGameRound, CrashGameBet)> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName);
    }

    public class CrashGameBetRepository : GameBetRepository, ICrashGameBetRepository
    {
        public CrashGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, int playerId, string operatorId, string gameName)
        {
            var round = await GetRoundAsync<CrashGameRound>(roundId, CollectionNameFormatter.Round(gameName));
            var bet = (await GetBetsAsync<CrashGameBet>(roundId, playerId, false, CollectionNameFormatter.Bet(gameName), operatorId)).FirstOrDefault();
            var betLogs = await GetBetLogsAsync<CrashGameBetLog>(roundId, playerId, CollectionNameFormatter.BetLog(gameName), operatorId);

            return (round, bet, betLogs);
        }

        public async Task<(CrashGameRound, CrashGameBet)> GetEndRoundAsync(long roundId, int playerId, string operatorId, string gameName)
        {
            var round = await GetRoundAsync<CrashGameRound>(roundId, CollectionNameFormatter.Round(gameName));
            var bet = (await GetBetsAsync<CrashGameBet>(roundId, playerId, false, CollectionNameFormatter.Bet(gameName), operatorId, x => x.Paid)).FirstOrDefault();

            return (round, bet);
        }
    }
}