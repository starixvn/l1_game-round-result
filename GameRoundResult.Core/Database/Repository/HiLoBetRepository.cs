using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IHiLoBetRepository
    {
        Task<(HiLoBet, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId);
    }
    public class HiLoBetRepository : GameBetRepository, IHiLoBetRepository
    {
        public HiLoBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(HiLoBet, IEnumerable<HiLoBetLog>)> GetAsync(long roundId, int memberId, string parterId)
        {
            var bet = await database.GetCollection<HiLoBet>(Document.GetCollectionName(typeof(HiLoBet)))
                .Find(x => x.Round == roundId && x.MemberId == memberId && x.PartnerId == parterId)
                .FirstOrDefaultAsync();

            if (bet != null)
            {
                var betLogs = await GetBetLogsAsync<HiLoBetLog>(roundId, memberId, Document.GetCollectionName(typeof(HiLoBetLog)), parterId);

                return (bet, betLogs);
            }

            return (null, Enumerable.Empty<HiLoBetLog>());
        }
    }
}