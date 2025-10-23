using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Web.PlinkoXGames
{
    public interface IPlinkoXGameTicketService
    {
        Task<PlinkoXGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class PlinkoXGameTicketService : IPlinkoXGameTicketService
    {
        private readonly IPlinkoXGameBetRepository repository;

        public PlinkoXGameTicketService(IPlinkoXGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<PlinkoXGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        => repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}
