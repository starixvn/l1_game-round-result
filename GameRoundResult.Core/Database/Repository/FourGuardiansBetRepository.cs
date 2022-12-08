using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IFourGuardiansBetRepository
    {
        Task<SlotRound> GetAsync<SlotRound>(long roundId, int playerId, string operatorId) where SlotRound : FourGuardiansRound;
    }

    public class FourGuardiansBetRepository : GameBetRepository, IFourGuardiansBetRepository
    {
        public FourGuardiansBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<SlotRound> GetAsync<SlotRound>(long roundId, int playerId, string operatorId) where SlotRound: FourGuardiansRound
        {
            return await database.GetCollection<SlotRound>(Document.GetCollectionName(typeof(SlotRound)))
               .Find(x => x.RoundId == roundId && x.PlayerId == playerId&& x.OperatorId == operatorId && x.Paid)
               .FirstOrDefaultAsync();
        }
    }
}