using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IBitcoinMasterTicketService
    {
        Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int memberId);
    }

    public class BitcoinMasterTicketService : IBitcoinMasterTicketService
    {
        private readonly IBitcoinMasterBetRepository repository;

        public BitcoinMasterTicketService(IBitcoinMasterBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int memberId)
        {
            return await repository.GetAsync(roundId, memberId);
        }
    }
}