using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static IMongoCollection<T> GetCollection<T>(this IMongoDatabase database)
        {
            return database.GetCollection<T>(Document.GetCollectionName(typeof(T)));
        }
    }
}
