using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameBetService
    {
        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId);

        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId);

        Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId);

        Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId);

        Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId);

        Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabAsync(long roundId, int memberId);

        Task<(BaccaratRound, BaccaratBet)> GetBaccaratAsync(long roundId, int memberId);
    }

    public class GameBetService : IGameBetService
    {
        private readonly IGameBetRepository repository;

        public GameBetService(IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId)
        {
            return await repository.GetBigSmallAsync(roundId, memberId);
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId)
        {
            return await repository.GetBigSmallTurboAsync(roundId, memberId);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId)
        {
            return await repository.GetOddEvenAsync(roundId, memberId);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId)
        {
            return await repository.GetOddEvenTurboAsync(roundId, memberId);
        }

        public async Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId)
        {
            return await repository.GetSeDieAsync(roundId, memberId);
        }

        public async Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId)
        {
            return await repository.GetMiniSeDieAsync(roundId, memberId);
        }

        public async Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId)
        {
            return await repository.GetDragonTigerAsync(roundId, memberId);
        }

        public async Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabAsync(long roundId, int memberId)
        {
            return await repository.GetFishPrawnCrabAsync(roundId, memberId);
        }

        public async Task<(BaccaratRound, BaccaratBet)> GetBaccaratAsync(long roundId, int memberId)
        {
            return await repository.GetBaccaratAsync(roundId, memberId);
        }
    }
}