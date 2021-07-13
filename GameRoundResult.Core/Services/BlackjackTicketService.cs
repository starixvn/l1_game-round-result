using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IBlackjackTicketService
    {
        Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int memberId);
    }

    public class BlackjackTicketService : IBlackjackTicketService
    {
        private readonly BlackjackBetRepository repository;

        public BlackjackTicketService(BlackjackBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int memberId)
        {
            return await repository.GetAsync(handId, memberId);
        }
    }
}