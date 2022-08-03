using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IFourGuardiansBetRepository
    {
        Task<SlotRound> GetAsync<SlotRound>(long roundId, int memberId, string operatorId) where SlotRound : FourGuardiansRound;
    }

    public class FourGuardiansBetRepository : GameBetRepository, IFourGuardiansBetRepository
    {
        public FourGuardiansBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<SlotRound> GetAsync<SlotRound>(long roundId, int memberId, string operatorId) where SlotRound: FourGuardiansRound
        {
            return await database.GetCollection<SlotRound>(Document.GetCollectionName(typeof(SlotRound)))
#pragma warning disable S1067 // Expressions should not be too complex
               .Find(x => x.RoundId == roundId 
                    && (x.PlayerId == memberId || x.MemberId == memberId)
                    && (x.PartnerId == operatorId || x.OperatorId == operatorId)
#pragma warning restore S1067 // Expressions should not be too complex
                ).FirstOrDefaultAsync();
        }
    }
}