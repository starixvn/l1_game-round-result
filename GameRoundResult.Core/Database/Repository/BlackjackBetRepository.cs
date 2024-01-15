using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBlackjackBetRepository
    {
        Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, string playerId, string operatorId);
    }
    public class BlackjackBetRepository : GameBetRepository, IBlackjackBetRepository
    {
        public BlackjackBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, string playerId, string operatorId)
        {
            var bet = await database.GetCollection<BlackjackBet>(Document.GetCollectionName(typeof(BlackjackBet)))
                .Find(x => x.HandId == handId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<BlackjackRound>(bet.RoundId, Document.GetCollectionName(typeof(BlackjackRound)));

                return (round, bet);
            }

            return (null, bet);
        }
    }
}