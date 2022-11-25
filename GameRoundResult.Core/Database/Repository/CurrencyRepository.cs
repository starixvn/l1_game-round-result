using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ICurrencyRepository
    {
        Task<Currency> Get(string name, string operatorId);
    }

    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IMongoCollection<Currency> collection;
        private const string currencyCacheKeys = "currency-";

        public CurrencyRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<Currency>(Document.GetCollectionName(typeof(Currency)));
        }

        public async Task<Currency> Get(string name, string operatorId)
        {
            return await collection.Find(x => x.Name == name && x.PartnerId == operatorId).FirstOrDefaultAsync();
        }
    }
}