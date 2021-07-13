using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public class FourGuardiansBetRepository : GameBetRepository
    {
        public FourGuardiansBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<FourGuardiansRound> GetAsync(long roundId, int memberId)
        {
            return await database.GetCollection<FourGuardiansRound>(Document.GetCollectionName(typeof(FourGuardiansRound)))
               .Find(x => x.Round == roundId && x.MemberId == memberId).FirstOrDefaultAsync();
        }
    }
}