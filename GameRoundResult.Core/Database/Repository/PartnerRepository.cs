using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IPartnerRepository
    {
        Task<Partner> Get(string partnerId, string partnerSecret);
    }

    public class PartnerRepository : IPartnerRepository
    {
        private readonly IMongoCollection<Partner> collection;

        public PartnerRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<Partner>(Document.GetCollectionName(typeof(Partner)));
        }

        public Task<Partner> Get(string partnerId, string partnerSecret)
        {
            return collection.Find(x => x.PartnerId == partnerId && x.SecretKey == partnerSecret).FirstOrDefaultAsync();
        }
    }
}