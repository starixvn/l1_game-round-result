using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IHiLoBetRepository
    {
        Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId);
    }
    public class HiLoBetRepository : GameBetRepository, IHiLoBetRepository
    {
        public HiLoBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(HiLoRound, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId)
        {
            var round = await database.GetCollection<HiLoRound>(Document.GetCollectionName(typeof(HiLoRound)))
                .Find(x => x.Round == roundId && x.MemberId == memberId && x.PartnerId == parterId && x.Paid)
                .FirstOrDefaultAsync();

            if (round != null)
            {
                var betLogs = await GetBetLogsAsync<HiLoBetLog>(roundId, memberId, Document.GetCollectionName(typeof(HiLoBetLog)), parterId);

                return (round, betLogs);
            }

            return (null, Enumerable.Empty<HiLoBetLog>());
        }
    }
}