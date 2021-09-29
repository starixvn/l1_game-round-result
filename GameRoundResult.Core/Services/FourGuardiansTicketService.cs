using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IFourGuardiansTicketService
    {
        Task<SlotRound> GetAsync<SlotRound>(long roundId, int memberId) where SlotRound : FourGuardiansRound;
    }

    public class FourGuardiansTicketService : IFourGuardiansTicketService
    {
        private readonly IFourGuardiansBetRepository repository;

        public FourGuardiansTicketService(IFourGuardiansBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SlotRound> GetAsync<SlotRound>(long roundId, int memberId) where SlotRound : FourGuardiansRound
        {
            return await repository.GetAsync<SlotRound>(roundId, memberId);
        }
    }
}