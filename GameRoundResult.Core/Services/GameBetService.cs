using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameBetService
    {
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;

        Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId);
    }

    public class GameBetService : IGameBetService
    {
        private readonly IGameBetRepository repository;

        public GameBetService(IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            return await repository.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(roundId, memberId, freeBet);
        }

        public async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int memberId, bool freeBet)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            return await repository.GetAsync<TRoundEntity, TBetEntity>(roundId, memberId, freeBet);
        }

        public async Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId)
        {
            return await repository.GetHeroesSlotAsync(roundId, memberId);
        }
    }
}