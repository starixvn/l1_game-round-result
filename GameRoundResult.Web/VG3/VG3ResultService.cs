using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Refit;

namespace GameRoundResult.Web.VG3
{
    public interface IVG3ResultApi
    {
        [Post("/BetHistory/GetAccessUrl")]
        Task<GameTicketAccessUrlResultModel> GetBetDetailsURL([Body] BetHistoryAccessUrlRequestModel request);
    }

    public interface IVG3ResultService
    {
        public AuthModel GetVG3Authentication();

        public bool IsVG3Ticket(BetHistoryAccessUrlRequestModel model);

        public Task<GameTicketAccessUrlResultModel> GetBetDetailsURL(BetHistoryAccessUrlRequestModel request);
    }

    public class VG3ResultService : IVG3ResultService
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase mongoDb;
        private readonly IVG3ResultApi api;
        private readonly string systemType;
        private readonly List<AuthModel> operators;
        private readonly DateTime mergingDate;

        private enum GameTypeVG3
        {
            BigSmall = 1,
            SeDie,
            FishPrawnCrab,
            BigSmallTurbo,
            OddEven,
            OddEvenTurbo,
            DragonTiger,
            KenoProMax,
            KenoMax = 12,
            KenoMax2 = 13,
            KenoMini = 14,
            KenoMini2 = 15,
            KenoEast = 16,
            KenoWest = 17,
            KenoSouth = 18,
            KenoNorth = 19,
            Roulette = 21,
            Blackjack = 23,
            SicBo = 25,
            FishPrawnCrabPro = 30,
            BaccaratDiamond = 32,
            BaccaratSapphire = 33,
            BaccaratRuby = 34,
            CasinoHoldemPoker = 39,
            TexasHoldemPoker = 42,
            PaiGowPoker = 44
        }

        public VG3ResultService(IConfiguration config, IVG3ResultApi api)
        {
            var vg3DbConnectionString = config.GetValue<string>("VG3:DatabaseSettings:ConnectionString");

            if (string.IsNullOrWhiteSpace(vg3DbConnectionString))
            {
                return;
            }
                

            mongoClient = new MongoClient(config.GetValue<string>("VG3:DatabaseSettings:ConnectionString"));
            mongoDb = mongoClient.GetDatabase(config.GetValue<string>("VG3:DatabaseSettings:DatabaseName"));
            systemType = config["SystemType"];
            operators = config.GetSection("VG3:Operators").Get<List<AuthModel>>();
            this.api = api;
            mergingDate = DateTime.Parse(config.GetValue<string>("VG3:MergingDate"));
        }

        public bool IsVG3Ticket(BetHistoryAccessUrlRequestModel model)
        {
            var maximumDays = new TimeSpan(7, 0, 0, 0);
            if (DateTime.Now - mergingDate > maximumDays)
            {
                return false;
            }
            if (systemType != "VG2" || !IsVG3Authentication(model.Auth))
            {
                return false;
            }
            var roundId = model.GameRoundId;
            var playerId = model.PlayerId;
            switch ((GameTypeVG3)model.GameTypeId)
            {
                case GameTypeVG3.BigSmall:
                    return ExistBet(roundId, playerId, "taixiu_ones");

                case GameTypeVG3.SeDie:
                    return ExistBet(roundId, playerId, "xocxoc_cuocs");

                case GameTypeVG3.FishPrawnCrab:
                    return ExistBet(roundId, playerId, "baucua_cuocs");

                case GameTypeVG3.BigSmallTurbo:
                    return ExistBet(roundId, playerId, "txturbo_ones");

                case GameTypeVG3.OddEven:
                    return ExistBet(roundId, playerId, "chanle_ones");

                case GameTypeVG3.OddEvenTurbo:
                    return ExistBet(roundId, playerId, "chanleturbo_ones");

                case GameTypeVG3.DragonTiger:
                    return ExistBet(roundId, playerId, "minidragontiger_cuocs");

                case GameTypeVG3.KenoProMax:
                    return ExistBet(roundId, playerId, "kenopromax_cuocs");

                case GameTypeVG3.Roulette:
                    return ExistBet(roundId, playerId, "roulette_ones");

                case GameTypeVG3.SicBo:
                    return ExistBet(roundId, playerId, "sicbo_cuocs");

                case GameTypeVG3.Blackjack:
                    return ExistBlackjackBet(roundId, playerId);

                case GameTypeVG3.FishPrawnCrabPro:
                    return ExistBet(roundId, playerId, "fishprawncrabpro_cuocs");

                case GameTypeVG3.KenoMax:
                    return ExistBet(roundId, playerId, "kenomax_ones");

                case GameTypeVG3.KenoMax2:
                    return ExistBet(roundId, playerId, "kenomax2_ones");

                case GameTypeVG3.KenoMini:
                    return ExistBet(roundId, playerId, "kenomini_ones");

                case GameTypeVG3.KenoMini2:
                    return ExistBet(roundId, playerId, "kenomini2_ones");

                case GameTypeVG3.KenoEast:
                    return ExistBet(roundId, playerId, "kenoeast_ones");

                case GameTypeVG3.KenoWest:
                    return ExistBet(roundId, playerId, "kenowest_ones");

                case GameTypeVG3.KenoSouth:
                    return ExistBet(roundId, playerId, "kenosouth_ones");

                case GameTypeVG3.KenoNorth:
                    return ExistBet(roundId, playerId, "kenonorth_ones");

                case GameTypeVG3.BaccaratDiamond:
                    return ExistBet(roundId, playerId, "baccaratdiamond_cuocs");

                case GameTypeVG3.BaccaratSapphire:
                    return ExistBet(roundId, playerId, "baccaratsapphire_cuocs");

                case GameTypeVG3.BaccaratRuby:
                    return ExistBet(roundId, playerId, "baccaratruby_cuocs");

                case GameTypeVG3.CasinoHoldemPoker:
                    return ExistBet(roundId, playerId, "casinoholdempoker_cuocs");

                case GameTypeVG3.TexasHoldemPoker:
                    return ExistBet(roundId, playerId, "texasholdempoker_cuocs");

                case GameTypeVG3.PaiGowPoker:
                    return ExistBet(roundId, playerId, "paigowpoker_cuocs");

                default:
                    return false;
            }
        }

        public Task<GameTicketAccessUrlResultModel> GetBetDetailsURL(BetHistoryAccessUrlRequestModel request)
            => api.GetBetDetailsURL(request);

        private bool ExistBet(long roundId, int playerId, string collectionName)
        {
            return mongoDb.GetCollection<BetEntity>(collectionName).Find(bet => bet.Phien == roundId && bet.MemberId == playerId && bet.Thanhtoan == true).Any();
        }

        private bool ExistBlackjackBet(long roundId, int playerId)
        {
            return mongoDb.GetCollection<BlackJackBetEntity>("blackjack_cuocs").Find(bet => bet.HandId == roundId && bet.MemberId == playerId && bet.Thanhtoan == true).Any();
        }

        private bool IsVG3Authentication(AuthModel authModel)
        {
            return operators.FirstOrDefault(o => o.OperatorId == authModel.OperatorId && o.OperatorSecret == authModel.OperatorSecret) != null;
        }

        public AuthModel GetVG3Authentication()
        {
            return operators[0];
        }
    }

    public class BetEntity
    {
        public long Phien { get; set; }
        public int? MemberId { get; set; }
        public bool Thanhtoan { get; set; }
    }

    public class BlackJackBetEntity : BetEntity
    {
        [BsonElement("id")]
        public long HandId { get; set; }
    }

    public static class VG3ServiceInit
    {
        public static void InitService(this IServiceCollection services, string domain)
        {
            if(string.IsNullOrEmpty(domain))
            {
                // Temporary hardcode for merging vg
                domain = "http://localhost";
            }
            services.AddSingleton(RestService.For<IVG3ResultApi>(domain));

            services.AddScoped<IVG3ResultService, VG3ResultService>();
        }
    }
}