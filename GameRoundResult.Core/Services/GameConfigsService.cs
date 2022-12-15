using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameConfigsService
    {
        Task<GameConfigs> GetByIdAsync(int gameId);
    }

    public class GameConfigsService : IGameConfigsService
    {
        private readonly IGameConfigsRepository repository;

        public GameConfigsService(IGameConfigsRepository repository)
        {
            this.repository = repository;
        }

        public Task<GameConfigs> GetByIdAsync(int gameId) =>
            repository.GetByIdAsync(gameId);
    }
}