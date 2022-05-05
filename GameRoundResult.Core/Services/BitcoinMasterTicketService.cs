using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IBitcoinMasterTicketService
    {
        Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int playerId, string operatorId);
    }

    public class BitcoinMasterTicketService : IBitcoinMasterTicketService
    {
        private readonly IBitcoinMasterBetRepository repository;

        public BitcoinMasterTicketService(IBitcoinMasterBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>, BitcoinMasterOne)> GetAsync(long roundId, int playerId, string operatorId)
        {
            return await repository.GetAsync(roundId, playerId, operatorId);
        }
    }
}