using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Web.PlinkoGames
{
    public interface IPlinkoGameTicketService
    {
        Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class PlinkoGameTicketService : IPlinkoGameTicketService
    {
        private readonly IPlinkoGameBetRepository repository;

        public PlinkoGameTicketService(IPlinkoGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<PlinkoGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        => repository.GetAsync(roundId, playerId, operatorId, gameName);
    }
}