using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IBlackjackBetRepository
    {
        Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int memberId);
    }
    public class BlackjackBetRepository : GameBetRepository, IBlackjackBetRepository
    {
        public BlackjackBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetAsync(long handId, int memberId)
        {
            var bet = await database.GetCollection<BlackjackBet>(Document.GetCollectionName(typeof(BlackjackBet)))
                .Find(x => x.HandId == handId && x.MemberId == memberId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<BlackjackRound>(bet.Round, Document.GetCollectionName(typeof(BlackjackRound)));

                return (round, bet);
            }

            return (null, bet);
        }
    }
}