using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.PlinkoGames;

namespace GameRoundResult.Web.PlinkoXGames
{
    public interface IPlinkoXGameTicketService : IPlinkoGameTicketService
    {
    }

    public class PlinkoXGameTicketService : IPlinkoXGameTicketService
    {
        private readonly IPlinkoGameBetRepository repository;

        public PlinkoXGameTicketService(IPlinkoGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        => repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}
