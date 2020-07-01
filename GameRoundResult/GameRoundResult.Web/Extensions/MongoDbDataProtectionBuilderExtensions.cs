using GameRoundResult.Web.DataProtection;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace GameRoundResult.Web.Extensions
{
    public static class MongoDbDataProtectionBuilderExtensions
    {
        public static IDataProtectionBuilder PersistKeysToMongoDb(this IDataProtectionBuilder builder, IConfiguration configuration)
        {
            var dbSettings = configuration.GetSection("DatabaseSettings");

            var mongoDatabase = new MongoClient(dbSettings["ConnectionString"]).GetDatabase(dbSettings["DatabaseName"]);

            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlRepository = new MongoDbXmlRepository(mongoDatabase, dbSettings["KeyCollection"], configuration["ApplicationName"]);
            });

            return builder;
        }
    }
}