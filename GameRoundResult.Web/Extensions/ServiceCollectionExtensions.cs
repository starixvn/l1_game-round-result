using System.Globalization;
using System.Linq;
using FluentValidation;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Database.Repository.RoundHistory;
using GameRoundResult.Core.Services;
using GameRoundResult.Core.Services.EndRoundInfo;
using GameRoundResult.Core.Services.RoundHistory;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CascadingSlotGames;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.CrashGames;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.RoundHistory;
using GameRoundResult.Web.Services;
using GameRoundResult.Web.SlotGames;
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
using Refit;

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

            services.AddScoped<IPontoonTicketService, PontoonTicketService>();
            services.AddScoped<IPontoonBetRepository, PontoonBetRepository>();

            services.AddScoped<IChineseBlackjackTicketService, ChineseBlackjackTicketService>();
            services.AddScoped<IChineseBlackjackBetRepository, ChineseBlackjackBetRepository>();

            services.AddScoped<IGeneralGameSettingRepository, GeneralGameSettingRepository>();
            services.AddScoped<IGeneralGameSettingService, GeneralGameSettingService>();

            services.AddScoped<IHiLoTicketService, HiLoTicketService>();
            services.AddScoped<IHiLoBetRepository, HiLoBetRepository>();

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
            services.AddScoped(typeof(DragonTigerFightTicketAccessor));
            services.AddScoped<PontoonTicketAccessor>();
            services.AddScoped<ChineseBlackjackTicketAccessor>();
            services.AddScoped(typeof(ColorGameTicketAccessor));
            services.AddScoped(typeof(BandarQiuQiuTicketAccessor));
            services.AddScoped(typeof(FootballDiceTicketAccessor));
            services.AddScoped(typeof(FootballSlotTicketAccessor<,,>));
            services.AddScoped(typeof(CoinTossTicketAccessor));
            services.AddScoped(typeof(FootballCoinTossTicketAccessor));
            services.AddScoped(typeof(SeDie3TicketAccessor<,,>));
            services.AddScoped(typeof(KaraKrusTicketAccessor<,,>));
            services.AddScoped(typeof(SevenUpDownTicketAccessor<,,>));

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
            services.AddScoped(typeof(BankingGameEndGameInfoService<,>));
            services.AddScoped<SpecialSeDieEndGameInfoService>();
            services.AddScoped<VipFishPrawnCrabEndGameInfoService>();
            services.AddScoped<SicBoEndGameInfoService>();
            services.AddScoped<VipSeDieWarEndGameInfoService>();

            services.AddScoped<LotteryEndGameInfoService>();
            services.AddScoped<ThreeCardsEndGameInfoService>();
            services.AddScoped<BitcoinMasterEndGameInfoService>();
            services.AddScoped(typeof(KenoMatchEndGameInfoService<,>));
            services.AddScoped(typeof(KenoPowerEndGameInfoService<,>));
            services.AddScoped<CasinoHoldemPokerEndGameInfoService>();
            services.AddScoped<HiLoEndGameInfoService>();
            services.AddScoped<TexasHoldemPokerEndGameInfoService>();
            services.AddScoped(typeof(UnbalancedBigSmallEndGameInfoService<,>));
            services.AddScoped<BaccaratTicketAccessor<BaccaratRound, BaccaratBet>>();
            services.AddScoped<BaccaratTicketAccessor<VipBaccaratRound, VipBaccaratBet>>();
            services.AddScoped<BaccaratTicketAccessor<BlockchainBaccaratRound, BlockchainBaccaratBet>>();
            services.AddScoped<BaccaratXTicketAccessor>();

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
            services.AddScoped<DragonTigerFightEndGameInfoService>();
            services.AddScoped<ColorGameEndGameInfoService>();
            services.AddScoped<BandarQiuQiuEndGameInfoService>();
            services.AddScoped<FootballDiceEndGameInfoService>();
            services.AddScoped<FootballSlotEndGameInfoService>();
            services.AddScoped<CoinTossEndGameInfoService>();
            services.AddScoped<FootballCoinTossEndGameInfoService>();
            services.AddScoped<BaccaratXEndGameInfoService>();
            services.AddScoped<SeDie3EndGameInfoService>();
            services.AddScoped<KaraKrusEndGameInfoService>();
            services.AddScoped<SevenUpDownEndGameInfoService>();

            services.AddScoped<IRoundHistoryRepository, RoundHistoryRepository>();
            services.AddScoped<IRoundHistoryService, RoundHistoryService>();
            services.AddScoped<IRoundHistoryAccessorFactory, RoundHistoryAccessorFactory>();
            services.AddScoped(typeof(RoundHistoryAccessor<,,,>));
            services.AddScoped(typeof(DrawRoundHistoryAccessor<,,,,,>));
            services.AddScoped<IUserInfoService, UserInfoService>();
            
            services.AddSlotGames();
            services.AddCascadingSlotGames();
            services.AddTransient(typeof(IJsonStringLocalizer<>), typeof(JsonStringLocalizer<>));
            services.AddCrashGames();
            services.AddScoped<IPartnerRequestAuthentication, PartnerRequestAuthentication>();
            services.AddScoped<IHmacHelpers, HmacHelpers>();

            services.AddScoped<IRoundHistoryAdditionalViewFactory, RoundHistoryAdditionalViewFactory>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RetrieveEndRoundInfoRequest>, RetrieveEndRoundInfoRequestValidator>();
        }

        public static void AddRestServices(this IServiceCollection services, IConfiguration configuration)
        {
            var gameManagementConfig = configuration.GetSection("GameManagementConfig").Get<GameManagementConfig>();

            if (!string.IsNullOrWhiteSpace(gameManagementConfig.IdentityServerAuth?.Url))
            {
                IdentityServerManager.Initialize(gameManagementConfig.IdentityServerAuth);

                var refitSettings = new RefitSettings
                {
                    AuthorizationHeaderValueGetter = IdentityServerManager.GetAccessToken,
                };

                services.AddSingleton(RestService.For<IGameManagementApi>(gameManagementConfig.Url, refitSettings));
            }
            else
            {
                services.AddSingleton(RestService.For<IGameManagementApi>(gameManagementConfig.Url));
            }
        }
    }
}