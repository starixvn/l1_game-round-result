using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameBetService
    {
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;
    }

    public class GameBetService : IGameBetService
    {
        private readonly IGameBetRepository repository;

        public GameBetService(IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            return await repository.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(roundId, playerId, freeBet, operatorId);
        }

        public async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, int playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            return await repository.GetAsync<TRoundEntity, TBetEntity>(roundId, playerId, freeBet, operatorId);
        }
    }
}