using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameConfigsRepository
    {
        Task<GameConfigs> GetByIdAsync(int gameId);
    }

    public class GameConfigsRepository : IGameConfigsRepository
    {
        protected readonly IMongoDatabase database;

        public GameConfigsRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public Task<GameConfigs> GetByIdAsync(int gameId)
        {
            return database
                .GetCollection<GameConfigs>(Document.GetCollectionName(typeof(GameConfigs)))
                .Find(x => x.GameId == gameId)
                .FirstOrDefaultAsync();
        }
    }
}