using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGeneralGameSettingRepository
    {

        Task<GameConfigEntity> GetConfigById(int gameType);

        Task<IEnumerable<GameConfigEntity>> GetAll();

    }
    public class GeneralGameSettingRepository: IGeneralGameSettingRepository
    {
        private readonly IMongoCollection<GameConfigEntity> collection;
        public GeneralGameSettingRepository(IMongoDatabase database) 
        {
            collection = database.GetCollection<GameConfigEntity>(Document.GetCollectionName(typeof(GameConfigEntity)));
        }

        public Task<GameConfigEntity> GetConfigById(int gameType)
        => collection.Find(x => x.GameId == gameType).FirstOrDefaultAsync();

        public async Task<IEnumerable<GameConfigEntity>> GetAll()
        => await collection.Find(_ => true).ToListAsync();
    }
}
