using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IHiLoTicketService
    {
        Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long handId, string playerId, string parterId);
    }

    public class HiLoTicketService : IHiLoTicketService
    {
        private readonly IHiLoBetRepository repository;

        public HiLoTicketService(IHiLoBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long handId, string playerId, string parterId)
        {
            return repository.GetAsync(handId, playerId, parterId);
        }
    }
}