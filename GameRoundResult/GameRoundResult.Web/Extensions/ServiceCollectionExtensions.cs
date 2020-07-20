using System.Globalization;
using System.Linq;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace GameRoundResult.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention(), new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
            var mongoClient = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            services.AddSingleton<IMongoClient>(mongoClient);
            var mongoDatabase = mongoClient.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            services.AddScoped(provider => mongoClient.GetDatabase(configuration["DatabaseSettings:DatabaseName"]));
        }

        public static void AddLocalizationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var cultures = configuration.GetSection("SupportedCultures").Get<string[]>()
               .Select(x => new CultureInfo(x)).ToList();

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                opts.DefaultRequestCulture = new RequestCulture(configuration["DefaultCulture"]);
                opts.SupportedCultures = new CultureInfo[] { cultures[0] };
                opts.SupportedUICultures = cultures;
                opts.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider { Options = opts });
            });

            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameRoundResultService, GameRoundResultService>();
            services.AddScoped<IGameRoundRepository, GameRoundRepository>();
            services.AddScoped<GameTypeLocalization>();
            services.AddScoped<IGameBetRepository, GameBetRepository>();
            services.AddScoped<IGameBetService, GameBetService>();
        }
    }
}