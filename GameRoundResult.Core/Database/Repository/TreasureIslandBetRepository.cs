using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ITreasureIslandBetRepository
    {
        Task<TreasureIslandRound> GetAsync(long roundId, int memberId);
    }

    public class TreasureIslandBetRepository : GameBetRepository, ITreasureIslandBetRepository
    {
        public TreasureIslandBetRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<TreasureIslandRound> GetAsync(long roundId, int memberId)
        {
            var winningIcons = new Dictionary<int, double>
            {
                [2] = 8,
                [5] = 8
            };
            var winningAmounts = new Dictionary<int, double>
            {
                [2] = 0.2,
                [5] = 0.8
            };

            return new TreasureIslandRound
            {
                BetLevel = 10,
                CoinValue = 100,
                TotalAmount = (decimal)10.1,
                BetWin = 20,

                Boards = new List<byte[]>
                {
                    new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                },
                TumbleWins = new List<double> { 0.8, 1.6 },
                TumbleMultipliers = new List<int> { 1, 3 },
                WinningIcons = new List<Dictionary<int, double>> { winningIcons, null },
                WinningAmounts = new List<Dictionary<int, double>> { winningAmounts, null },
            };

            var collection = database.GetCollection<TreasureIslandRound>(Document.GetCollectionName(typeof(TreasureIslandRound)));

            return await collection.Find(x => x.Round == roundId && x.MemberId == memberId).FirstOrDefaultAsync();
        }
    }
}