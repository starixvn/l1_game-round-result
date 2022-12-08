using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ISlotGameBetRepository
    {
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, GameConfigs gameConfigs);
    }

    public class SlotGameBetRepository : GameBetRepository, ISlotGameBetRepository
    {
        public SlotGameBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, GameConfigs gameConfigs)
        {
            return await database.GetCollection<SlotGameRound>($"{gameConfigs.Name}${gameConfigs.RoundCollectionSuffix}")
               .Find(x => x.RoundId == roundId && x.PlayerId == playerId && x.OperatorId == operatorId && x.Paid)
               .FirstOrDefaultAsync();
        }
    }
}