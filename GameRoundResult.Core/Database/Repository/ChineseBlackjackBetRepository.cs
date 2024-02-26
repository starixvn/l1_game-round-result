using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IChineseBlackjackBetRepository
    {
        Task<(ChineseBlackjackRound, ChineseBlackjackBet)> GetAsync(long handId, string playerId, string operatorId);
    }
    public class ChineseBlackjackBetRepository : GameBetRepository, IChineseBlackjackBetRepository
    {
        public ChineseBlackjackBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<(ChineseBlackjackRound, ChineseBlackjackBet)> GetAsync(long handId, string playerId, string operatorId)
        {
            var bet = await database.GetCollection<ChineseBlackjackBet>(Document.GetCollectionName(typeof(ChineseBlackjackBet)))
                .Find(x => x.HandId == handId && x.PlayerId == playerId && x.OperatorId == operatorId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<ChineseBlackjackRound>(bet.RoundId, Document.GetCollectionName(typeof(ChineseBlackjackRound)));

                return (round, bet);
            }

            return (null, bet);
        }
    }
}