using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameBetRepository
    {
        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId);

        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId);

        Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId);

        Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId);

        Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId);

        Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabRoundAsync(long roundId, int memberId);
    }

    public class GameBetRepository : IGameBetRepository
    {
        private readonly IMongoDatabase database;

        public GameBetRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BigSmallRound>(roundId, MiniGameRoundCollections.BigSmallRound);
            var bets = await GetBetsAsync<BigSmallBet>(roundId, memberId, MiniGameBetCollections.BigSmallBet);

            return (round, bets);
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BigSmallRound>(roundId, MiniGameRoundCollections.BigSmallTurboRound);
            var bets = await GetBetsAsync<BigSmallBet>(roundId, memberId, MiniGameBetCollections.BigSmallTurboBet);

            return (round, bets);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<OddEvenRound>(roundId, MiniGameRoundCollections.OddEvenRound);
            var bets = await GetBetsAsync<OddEvenBet>(roundId, memberId, MiniGameBetCollections.OddEvenBet);

            return (round, bets);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<OddEvenRound>(roundId, MiniGameRoundCollections.OddEvenTurboRound);
            var bets = await GetBetsAsync<OddEvenBet>(roundId, memberId, MiniGameBetCollections.OddEvenTurboBet);

            return (round, bets);
        }

        public async Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<SeDieRound>(roundId, MiniGameRoundCollections.SeDieRound);
            var bets = (await GetBetsAsync<SeDieBet>(roundId, memberId, MiniGameBetCollections.SeDieBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<MiniSeDieRound>(roundId, MiniGameRoundCollections.MiniSeDieRound);
            var bets = (await GetBetsAsync<MiniSeDieBet>(roundId, memberId, MiniGameBetCollections.MiniSeDieBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<DragonTigerRound>(roundId, MiniGameRoundCollections.DragonTigerRound);
            var bets = (await GetBetsAsync<DragonTigerBet>(roundId, memberId, MiniGameBetCollections.DragonTigetBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabRoundAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<FishPrawnCrabRound>(roundId, MiniGameRoundCollections.FishPrawnRound);
            var bets = (await GetBetsAsync<FishPrawnCrabBet>(roundId, memberId, MiniGameBetCollections.FishPrawnCrabBet)).FirstOrDefault();

            return (round, bets);
        }


        private async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int memberId, string collectionName) where T: BaseBetEntity
        {
            return await database.GetCollection<T>(collectionName).Find(x => x.MemberId == memberId && x.Round == roundId).ToListAsync();
        }

        private async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
        {
            return await database.GetCollection<T>(collectionName).Find(x =>  x.Round == roundId).FirstOrDefaultAsync();
        }
    }
}