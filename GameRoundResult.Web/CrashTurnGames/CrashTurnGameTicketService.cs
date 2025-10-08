using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Web.CrashTurnGames
{
    public interface ICrashTurnGameTicketService
    {
        Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class CrashTurnGameTicketService : ICrashTurnGameTicketService
    {
        private readonly ICrashGameBetRepository repository;

        public CrashTurnGameTicketService(ICrashGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<(CrashGameRound, CrashGameBet, IEnumerable<CrashGameBetLog>)> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        => repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}