using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IPartnerRepository
    {
        Task<Partner> Get(string partnerId, string partnerSecret);

        Task<Partner> GetById(string operatorId);

        Task<IEnumerable<Partner>> GetAll();
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

        public Task<Partner> GetById(string operatorId)
        {
            return collection.Find(x => x.PartnerId == operatorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Partner>> GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }
    }
}