using System.Globalization;
using System.Linq;
using FluentValidation;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.Validators;
using GameRoundResult.Web.ViewFactory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
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
            BsonSerializer.RegisterSerializationProvider(new DecimalSerializationProvider());
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
            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddScoped<IGameRoundResultService, GameRoundResultService>();
            services.AddScoped<IGameRoundRepository, GameRoundRepository>();
            services.AddScoped<GameTypeLocalization>();
            services.AddScoped<IGameBetRepository, GameBetRepository>();
            services.AddScoped<IGameBetService, GameBetService>();
            services.AddScoped<IGlobalConfigService, GlobalConfigService>();
            services.AddScoped<IGlobalConfigRepository, GlobalConfigRepository>();
            services.AddScoped<IPartnerConfigService, PartnerConfigService>();
            services.AddScoped<IPartnerConfigRepository, PartnerConfigRepository>();
            services.AddScoped<IGameConfigsRepository, GameConfigsRepository>();

            services.AddScoped<IGameRoundAccessorFactory, GameRoundAccessorFactory>();
            services.AddScoped(typeof(GameRoundAccessor<,>));
            services.AddScoped(typeof(KenoMatchRoundAccessor<>));
            services.AddScoped(typeof(KenoPowerRoundAccessor<>));
            services.AddScoped<IKenoMatchRoundResultService, KenoMatchRoundResultService>();
            services.AddScoped<IKenoPowerRoundResultService, KenoPowerRoundResultService>();
            services.AddScoped<IRoundResultViewFactory, RoundResultViewFactory>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IBlackjackTicketService, BlackjackTicketService>();
            services.AddScoped<IBlackjackBetRepository, BlackjackBetRepository>();

            services.AddScoped<IHiLoTicketService, HiLoTicketService>();
            services.AddScoped<IHiLoBetRepository, HiLoBetRepository>();

            services.AddScoped<ISlotGameTicketService, SlotGameTicketService>();
            services.AddScoped<ISlotGameBetRepository, SlotGameBetRepository>();

            services.AddScoped<IBaseCascadingSlotTicketService, BaseCascadingSlotTicketService>();
            services.AddScoped<IBaseCascadingSlotBetRepository, BaseCascadingSlotBetRepository>();

            services.AddScoped<IBitcoinMasterTicketService, BitcoinMasterTicketService>();
            services.AddScoped<IBitcoinMasterBetRepository, BitcoinMasterBetRepository>();

            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<ICurrencyGroupService, CurrencyGroupService>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<ICurrencyGroupRepository, CurrencyGroupRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            services.AddScoped(typeof(BigSmallTicketAccessor<,,>));

            services.AddScoped<BlackjackTicketAccessor>();
            services.AddScoped<DragonTigerTicketAccessor>();
            services.AddScoped<FishPrawnCrabTicketAccessor>();
            services.AddScoped<SlotGameTicketAccessor>();
            services.AddScoped(typeof(BaseCascadingSlotTicketAccessor<,>));
            services.AddScoped<KenoProMaxTicketAccessor>();
            services.AddScoped<LotteryTicketAccessor>();
            services.AddScoped(typeof(MiniKenoTicketAccessor<,>));
            services.AddScoped(typeof(MiniSeDieTicketAccessor<,>));
            services.AddScoped<OddEvenTicketAccessor>();
            services.AddScoped<RouletteTicketAccessor>();
            services.AddScoped<SeDieTicketAccessor>();
            services.AddScoped<SicBoTicketAccessor>();
            services.AddScoped<SpecialSeDieTicketAccessor>();

            services.AddScoped<VipFishPrawnCrabTicketAccessor>();
            services.AddScoped<VipSeDieTicketAccessor>();
            services.AddScoped<VipSeDieWarTicketAccessor>();
            services.AddScoped(typeof(KenoMatchTicketAccessor<,,>));
            services.AddScoped(typeof(KenoPowerTicketAccessor<,,>));
            services.AddScoped<ThreeCardsTicketAccessor>();
            services.AddScoped(typeof(BitcoinMasterTicketAccessor));
            services.AddScoped<CasinoHoldemPokerTicketAccessor>();
            services.AddScoped<HiLoTicketAccessor>();
            services.AddScoped<TexasHoldemPokerTicketAccessor>();
            services.AddScoped(typeof(UnbalancedBigSmallTicketAccessor<,,>));
            services.AddScoped(typeof(MiniSeDieTicketAccessor<,>));
            services.AddScoped(typeof(FruitSlotTicketAccessor<,,>));
            services.AddScoped<FanTanTicketAccessor>();
            services.AddScoped(typeof(Win3CardsTicketAccessor));

            services.AddScoped<IGameTicketAccessorFactory, GameTicketAccessorFactory>();

            services.AddScoped<IEndGameInfoServiceFactory, EndGameInfoServiceFactory>();
            services.AddScoped<BigSmallEndGameInfoService>();
            services.AddScoped<BigSmallTurboEndGameInfoService>();
            services.AddScoped<OddEvenTurboEndGameInfoService>();
            services.AddScoped<FishPrawnCrabEndGameInfoService>();
            services.AddScoped<SeDieEndGameInfoService>();
            services.AddScoped(typeof(MiniSeDieEndGameInfoService<,>));
            services.AddScoped<DragonTigerEndGameInfoService>();
            services.AddScoped<KenoProMaxEndGameInfoService>();
            services.AddScoped<RouletteEndGameInfoService>();
            services.AddScoped<VipSeDieEndGameInfoService>();
            services.AddScoped<BlackjackEndGameInfoService>();
            services.AddScoped<SpecialSeDieEndGameInfoService>();
            services.AddScoped<VipFishPrawnCrabEndGameInfoService>();
            services.AddScoped<SicBoEndGameInfoService>();
            services.AddScoped<VipSeDieWarEndGameInfoService>();
            services.AddScoped<SlotGameEndGameInfoService>();
            services.AddScoped<LotteryEndGameInfoService>();
            services.AddScoped<ThreeCardsEndGameInfoService>();
            services.AddScoped<BitcoinMasterEndGameInfoService>();
            services.AddScoped(typeof(KenoMatchEndGameInfoService<,>));
            services.AddScoped(typeof(KenoPowerEndGameInfoService<,>));
            services.AddScoped<CasinoHoldemPokerEndGameInfoService>();
            services.AddScoped<HiLoEndGameInfoService>();
            services.AddScoped<TexasHoldemPokerEndGameInfoService>();
            services.AddScoped<TreasureIslandEndRoundInfoService>();
            services.AddScoped(typeof(UnbalancedBigSmallEndGameInfoService<,>));
            services.AddScoped<BaccaratTicketAccessor<BaccaratRound, BaccaratBet>>();
            services.AddScoped<BaccaratTicketAccessor<VipBaccaratRound, VipBaccaratBet>>();
            services.AddScoped<BaccaratTicketAccessor<BlockchainBaccaratRound, BlockchainBaccaratBet>>();


            services.AddScoped<BaccaratEndGameInfoService<BaccaratRound, BaccaratBet>>();
            services.AddScoped<BaccaratEndGameInfoService<VipBaccaratRound, VipBaccaratBet>>();
            services.AddScoped<BaccaratEndGameInfoService<BlockchainBaccaratRound, BlockchainBaccaratBet>>();

            services.AddScoped<MiniKenoEndGameInfoService<KenoMaxRound, KenoMaxOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoMax2Round, KenoMax2One>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoMiniRound, KenoMiniOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoMini2Round, KenoMini2One>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoEastRound, KenoEastOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoWestRound, KenoWestOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoSouthRound, KenoSouthOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<KenoNorthRound, KenoNorthOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<MegaKenoRound, MegaKenoOne>>();
            services.AddScoped<MiniKenoEndGameInfoService<MegaKeno2Round, MegaKeno2One>>();
            services.AddScoped<FruitSlotEndGameInfoService>();
            services.AddScoped<FanTanEndGameInfoService>();
            services.AddScoped<Win3CardsEndGameInfoService>();
            services.AddScoped<FortuneCatEndGameInfoService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RetrieveEndRoundInfoRequest>, RetrieveEndRoundInfoRequestValidator>();
        }
    }
}