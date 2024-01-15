using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IPontoonBetRepository
    {
        Task<(PontoonRound, PontoonBet)> GetAsync(long handId, string playerId, string operatorId);
    }
    public class PontoonBetRepository : GameBetRepository, IPontoonBetRepository
    {
        public PontoonBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(PontoonRound, PontoonBet)> GetAsync(long handId, string playerId, string operatorId)
        {
            var bet = await database.GetCollection<PontoonBet>(Document.GetCollectionName(typeof(PontoonBet)))
                .Find(x => x.HandId == handId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<PontoonRound>(bet.RoundId, Document.GetCollectionName(typeof(PontoonRound)));

                return (round, bet);
            }

            return (null, bet);
        }
    }
}