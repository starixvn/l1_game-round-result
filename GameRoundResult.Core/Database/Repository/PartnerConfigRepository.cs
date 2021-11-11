using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IPartnerConfigRepository
    {
        Task<PartnerConfig> GetAsync(string partnerId);
    }

    public class PartnerConfigRepository : IPartnerConfigRepository
    {
        private readonly IMongoCollection<PartnerConfig> collection;

        public PartnerConfigRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<PartnerConfig>(Document.GetCollectionName(typeof(PartnerConfig)));
        }

        public async Task<PartnerConfig> GetAsync(string partnerId)
        {
            return await collection.Find(x => x.Type == GlobalConfigType.GameSiteExclusions && x.PartnerId == partnerId).FirstOrDefaultAsync();
        }
    }
}