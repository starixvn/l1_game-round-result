using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Web.CrashGames
{
    public interface ICrashGameTicketService
    {
        Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, int playerId, string operatorId, string gameName);
    }

    public class CrashGameTicketService : ICrashGameTicketService
    {
        private readonly ICrashGameBetRepository repository;

        public CrashGameTicketService(ICrashGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, int playerId, string operatorId, string gameName)
        => repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}