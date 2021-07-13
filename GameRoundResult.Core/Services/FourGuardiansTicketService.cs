using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IFourGuardiansTicketService
    {
        Task<FourGuardiansRound> GetAsync(long roundId, int memberId);
    }

    public class FourGuardiansTicketService : IFourGuardiansTicketService
    {
        private readonly FourGuardiansBetRepository repository;

        public FourGuardiansTicketService(FourGuardiansBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<FourGuardiansRound> GetAsync(long roundId, int memberId)
        {
            return await repository.GetAsync(roundId, memberId);
        }
    }
}