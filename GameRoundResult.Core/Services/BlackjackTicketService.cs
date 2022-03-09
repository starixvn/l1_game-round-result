using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IBlackjackTicketService
    {
        Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int playerId, string operatorId);
    }

    public class BlackjackTicketService : IBlackjackTicketService
    {
        private readonly IBlackjackBetRepository repository;

        public BlackjackTicketService(IBlackjackBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int playerId, string operatorId)
        {
            return await repository.GetAsync(handId, playerId, operatorId);
        }
    }
}