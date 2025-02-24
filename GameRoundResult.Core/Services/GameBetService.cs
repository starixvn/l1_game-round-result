using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameBetService
    {
        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;

        Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity;

        Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
           where TRoundEntity : GameRound
           where TBetEntity : BaseBetEntity;

        Task<(TOneEntity, IEnumerable<TBetEntity>)> GetBetAsync<TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
           where TOneEntity : BaseCrashTurnBetEntity
           where TBetEntity : BaseBetLogEntity;
    }

    public class GameBetService : IGameBetService
    {
        private readonly IGameBetRepository repository;

        public GameBetService(IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            return await repository.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(roundId, playerId, freeBet, operatorId);
        }

        public async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            return await repository.GetAsync<TRoundEntity, TBetEntity>(roundId, playerId, freeBet, operatorId);
        }

        public async Task<(TRoundEntity, IEnumerable<TBetEntity>, TOneEntity)> GetAsync<TRoundEntity, TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TOneEntity : BaseBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            return await repository.GetAsync<TRoundEntity, TOneEntity, TBetEntity>(roundId, playerId, freeBet, operatorId, gameName);
        }

        public async Task<(TRoundEntity, TBetEntity)> GetAsync<TRoundEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TRoundEntity : GameRound
            where TBetEntity : BaseBetEntity
        {
            return await repository.GetAsync<TRoundEntity, TBetEntity>(roundId, playerId, freeBet, operatorId, gameName);
        }

        public async Task<(TOneEntity, IEnumerable<TBetEntity>)> GetBetAsync<TOneEntity, TBetEntity>(long roundId, string playerId, bool freeBet, string operatorId, string gameName)
            where TOneEntity : BaseCrashTurnBetEntity
            where TBetEntity : BaseBetLogEntity
        {
            return await repository.GetBetAsync<TOneEntity, TBetEntity>(roundId, playerId, freeBet, operatorId, gameName);
        }
    }
}