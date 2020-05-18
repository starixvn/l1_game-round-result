using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameRoundRepository
    {
        Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId);

        Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId);
    }

    public class GameRoundRepository : IGameRoundRepository
    {
        private readonly IMongoDatabase database;

        public GameRoundRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase("minigame");
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<BigSmallRound>(MiniGameCollections.BigSmallRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<BigSmallRound>> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<BigSmallRound>(MiniGameCollections.BigSmallTurboRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<OddEvenRound>(MiniGameCollections.OddEvenTurboRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<OddEvenRound>> GetOddEvenRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<OddEvenRound>(MiniGameCollections.OddEvenRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<ShakeThePlateRound>> GetShakeThePlateRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<ShakeThePlateRound>(MiniGameCollections.ShakeThePlateRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<FishPrawnRound>> GetFishPrawnRoundResultAsync(DateTime date, long roundId)
        {
            var collection = database.GetCollection<FishPrawnRound>(MiniGameCollections.FishPrawnRound);
            var fromDate = date.Date;
            var toDate = fromDate.AddDays(1);
            return await collection.Aggregate()
                .Match(x => x.Time >= fromDate && x.Time < toDate && (roundId == 0 || x.Round == roundId))
                .SortByDescending(x => x.Time)
                .ToListAsync();
        }
    }
}