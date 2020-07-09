using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
