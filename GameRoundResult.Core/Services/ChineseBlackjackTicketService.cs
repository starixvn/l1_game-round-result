using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IChineseBlackjackTicketService
    {
        Task<(ChineseBlackjackRound, ChineseBlackjackBet)> GetAsync(long handId, int playerId, string operatorId);
    }

    public class ChineseBlackjackTicketService : IChineseBlackjackTicketService
    {
        private readonly IChineseBlackjackBetRepository repository;

        public ChineseBlackjackTicketService(IChineseBlackjackBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(ChineseBlackjackRound, ChineseBlackjackBet)> GetAsync(long handId, int playerId, string operatorId)
        {
            return await repository.GetAsync(handId, playerId, operatorId);
        }
    }
}