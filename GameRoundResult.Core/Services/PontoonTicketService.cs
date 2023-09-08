using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IPontoonTicketService
    {
        Task<(PontoonRound, PontoonBet)> GetAsync(long handId, int playerId, string operatorId);
    }

    public class PontoonTicketService : IPontoonTicketService
    {
        private readonly IPontoonBetRepository repository;

        public PontoonTicketService(IPontoonBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(PontoonRound, PontoonBet)> GetAsync(long handId, int playerId, string operatorId)
        {
            return await repository.GetAsync(handId, playerId, operatorId);
        }
    }
}