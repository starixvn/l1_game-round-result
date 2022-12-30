namespace GameRoundResult.Core.Database.Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using GameRoundResult.Core.Database.Entities;
    using MongoDB.Driver;

    public interface IBaseCascadingSlotBetRepository
    {
        Task<(SlotRound, TotalMultiplier)> GetAsync<SlotRound, TotalMultiplier>(long roundId, int playerId, string operatorId)
            where SlotRound : BaseCascadingSlotRoundEntity where TotalMultiplier : BaseCascadingSlotTotalMultiplierEntity;
    }

    public class BaseCascadingSlotBetRepository : GameBetRepository, IBaseCascadingSlotBetRepository
    {
        public BaseCascadingSlotBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(SlotRound, TotalMultiplier)> GetAsync<SlotRound, TotalMultiplier>(long roundId, int playerId, string operatorId)
            where SlotRound : BaseCascadingSlotRoundEntity
            where TotalMultiplier : BaseCascadingSlotTotalMultiplierEntity
        {
            var round = await database.GetCollection<SlotRound>(Document.GetCollectionName(typeof(SlotRound)))
               .Find(x => x.RoundId == roundId && x.PlayerId == playerId && x.OperatorId == operatorId)
               .FirstOrDefaultAsync();

            if (round != null)
            {
                var totalMultipliers = database.GetCollection<TotalMultiplier>(Document.GetCollectionName(typeof(TotalMultiplier)))
               .Find(x => x.PlayerId == playerId).ToList();

                if (totalMultipliers.Count > 0)
                {
                    var totalMultiplier = totalMultipliers.FirstOrDefault(e => e.Rounds.Any(x => x.RoundId == roundId));
                    return (round, totalMultiplier);
                }
            }

            return (round, null);
        }
    }
}