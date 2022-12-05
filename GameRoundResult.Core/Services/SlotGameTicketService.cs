using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ISlotGameTicketService
    {
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, GameConfigs gameConfigs);
    }

    public class SlotGameTicketService : ISlotGameTicketService
    {
        private readonly ISlotGameBetRepository repository;

        public SlotGameTicketService(ISlotGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, GameConfigs gameConfigs) 
        {
            return await repository.GetAsync(roundId, playerId, operatorId, gameConfigs);
        }
    }
}