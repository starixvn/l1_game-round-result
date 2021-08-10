using System.Globalization;
using System.Linq;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Accessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using GameRoundResult.Web.ViewFactory;

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
                opts.SupportedCultures = cultures;
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
            services.AddScoped<IGlobalConfigService, GlobalConfigService>();
            services.AddScoped<IGlobalConfigRepository, GlobalConfigRepository>();

            services.AddScoped<IGameRoundAccessorFactory, GameRoundAccessorFactory>();
            services.AddScoped(typeof(GameRoundAccessor<,>));
            services.AddScoped(typeof(KenoMatchRoundAccessor<>));
            services.AddScoped<IKenoMatchRoundResultService, KenoMatchRoundResultService>();
            services.AddScoped<IRoundResultViewFactory, RoundResultViewFactory>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IBlackjackTicketService, BlackjackTicketService>();
            services.AddScoped<IBlackjackBetRepository, BlackjackBetRepository>();

            services.AddScoped<IFourGuardiansTicketService, FourGuardiansTicketService>();
            services.AddScoped<FourGuardiansBetRepository>();

            services.AddScoped(typeof(BigSmallTicketAccessor<,,>));
            services.AddScoped<BaccaratTicketAccessor>();
            services.AddScoped<BlackjackTicketAccessor>();
            services.AddScoped<DragonTigerTicketAccessor>();
            services.AddScoped<FishPrawnCrabTicketAccessor>();
            services.AddScoped<FourGuardiansTicketAccessor>();
            services.AddScoped<KenoProMaxTicketAccessor>();
            services.AddScoped<LotteryTicketAccessor>();
            services.AddScoped(typeof(MiniKenoTicketAccessor<,,>));
            services.AddScoped<MiniSeDieTicketAccessor>();
            services.AddScoped<OddEvenTicketAccessor>();
            services.AddScoped<RouletteTicketAccessor>();
            services.AddScoped<SeDieTicketAccessor>();
            services.AddScoped<SicBoTicketAccessor>();
            services.AddScoped<SpecialSeDieTicketAccessor>();
            services.AddScoped<VipBaccaratTicketAccessor>();
            services.AddScoped<VipFishPrawnCrabTicketAccessor>();
            services.AddScoped<VipSeDieTicketAccessor>();
            services.AddScoped<VipSeDieWarTicketAccessor>();

            services.AddScoped<IGameTicketAccessorFactory, GameTicketAccessorFactory>();
        }
    }
}