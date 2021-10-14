using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGlobalConfigRepository
    {
        Task<GlobalConfig> GetAsync();
    }

    public class GlobalConfigRepository : IGlobalConfigRepository
    {
        private readonly IMongoCollection<GlobalConfig> collection;

        public GlobalConfigRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<GlobalConfig>(CommonCollections.GlobalConfig);
        }

        public async Task<GlobalConfig> GetAsync()
        {
            var r = collection.Find(x => x.Type == GlobalConfigType.GameSiteExclusions).FirstOrDefault();

            return await collection.Find(x => x.Type == GlobalConfigType.GameSiteExclusions).FirstOrDefaultAsync();
        }
    }
}