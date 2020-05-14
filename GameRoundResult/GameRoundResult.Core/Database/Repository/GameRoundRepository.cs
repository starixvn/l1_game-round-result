using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameRoundRepository
    {
        Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date);

        Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date);
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase("minigame");
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date)
        {
            var collection = database.GetCollection<BigSmallRound>("taixiu_phiens");
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return (await collection.FindAsync(x => x.Time >= fromDate && x.Time < toDate)).ToList();
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date)
        {
            var collection = database.GetCollection<BigSmallRound>("txturbo_phiens");
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return (await collection.FindAsync(x => x.Time >= fromDate && x.Time < toDate)).ToList();
        }
    }
}