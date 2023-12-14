using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Web.SlotGames
{
    public interface ISlotGameTicketService
    {
        Task<SlotGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName);
    }

    public class SlotGameTicketService : ISlotGameTicketService
    {
        private readonly ISlotGameBetRepository repository;

        public SlotGameTicketService(ISlotGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<SlotGameRound> GetAsync(long roundId, string playerId, string operatorId, string gameName)
        => repository.GetAsync<SlotGameRound>(roundId, playerId, operatorId, gameName);
    }
}