using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ICurrencyGroupRepository
    {
        Task<CurrencyGroup> GetById(string id);
    }

    public class CurrencyGroupRepository : ICurrencyGroupRepository
    {
        private readonly IMongoCollection<CurrencyGroup> collection;

        public CurrencyGroupRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<CurrencyGroup>(Document.GetCollectionName(typeof(CurrencyGroup)));
        }

        public async Task<CurrencyGroup> GetById(string id)
        {
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}