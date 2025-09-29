using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Core.RoundHistory.Models;
using GameRoundResult.Core.Services;
using GameRoundResult.Core.Services.RoundHistory;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Web.PlinkoGames.ViewModels;
using GameRoundResult.Web.Requests.RoundHistory;
using GameRoundResult.Web.RoundHistory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace GameRoundResult.Web.PlinkoGames
{
    public class PlinkoGameRoundHistoryHandler : IRoundHistoryAccessor
    {
        private readonly IRoundHistoryService roundHistoryService;
        protected readonly IUserInfoService userInfoService;
        protected readonly IPartnerService partnerService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public PlinkoGameRoundHistoryHandler(IRoundHistoryService roundHistoryService, IUserInfoService userInfoService, IPartnerService partnerService, IMapper mapper, IConfiguration configuration)
        {
            this.roundHistoryService = roundHistoryService;
            this.userInfoService = userInfoService;
            this.partnerService = partnerService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<RoundHistoryViewModel> GetAsync(RoundHistoryRequest request)
        {
            var timeZone = TZConvert.GetTimeZoneInfo("SE Asia Standard Time");
            var roundResult = await roundHistoryService.GetRoundAsync<PlinkoGameRound>(request.RoundId, BuildRoundFilterExpression(request.RoundId), request.GameConfigs.Name);

            var bets = new List<RoundHistoryBetEntity>();
            if (roundResult != null)
            {
                bets.Add(CreateBetFromRound(roundResult));
            }

            var betsWithUserInfo = await this.GetBetRecordsWithUserInfo(bets, request.Username, request.ExcludeBot);
            
            var betViewModel = betsWithUserInfo.Select(r => r.ToBetViewModel<RoundHistoryBetEntity, RoundHistoryBetViewModel>(mapper, timeZone.BaseUtcOffset));

            return new RoundHistoryViewModel
            {
                Round = MapRoundResult(roundResult, timeZone, request),
                Bets = betViewModel,
                Request = request,
                BaseCurrencyMultiplier = BaseCurrencyConfig.MultiplierMapper[configuration["SystemType"]],
                BaseCurrency = BaseCurrencyConfig.CurrencyMapper[configuration["SystemType"]]
            };
        }

        private static RoundHistoryBetEntity CreateBetFromRound(PlinkoGameRound round)
        {
            return new RoundHistoryBetEntity
            {
                UserId = round.PlayerId,
                Uid = round.Uid,
                Name = round.Name,
                TotalAmount = round.TotalAmount,
                Time = round.Time,
                OperatorName = round.OperatorId,
                Currency = round.Currency,
                Rate = round.Rate,
                Betwin = round.BetWin,
                PlayerId = round.PlayerId,
                OperatorId = round.OperatorId
            };
        }

        protected async Task<IEnumerable<RoundHistoryBetEntity>> GetBetRecordsWithUserInfo(IEnumerable<RoundHistoryBetEntity> bets, string username, bool excludeBot)
        {
            if (bets.Any())
            {
                var userInfos = await userInfoService.FilterByUidsAndUserName(bets.Select(x => x.Uid), username, excludeBot);

                var operatorIds = bets.Select(x => x.OperatorId).Distinct().ToList();
                var partnerTasks = operatorIds.Select(async operatorId =>
                {
                    var partner = await partnerService.GetById(operatorId);
                    return new { OperatorId = operatorId, Name = partner?.Name ?? string.Empty };
                });
                
                var partnerResults = await Task.WhenAll(partnerTasks);
                var partners = partnerResults.ToDictionary(x => x.OperatorId, x => x.Name);

                return bets.Join(userInfos, bet => bet.Uid, userInfo => userInfo.Uid, (bet, userInfo) =>
                {
                    bet.Username = userInfo.Username;
                    bet.Nickname = userInfo.NickName;
                    bet.OperatorName = partners.GetValueOrDefault(bet.OperatorId, string.Empty);
                    return bet;
                }).ToList();
            }

            return Enumerable.Empty<RoundHistoryBetEntity>();
        }

        protected virtual PlinkoGameRoundResultViewModel MapRoundResult(PlinkoGameRound roundResult, TimeZoneInfo timeZone, RoundHistoryRequest request)
        {
            var roundViewModel = roundResult?.ToViewModel<PlinkoGameRound, PlinkoGameRoundResultViewModel>(mapper, timeZone.BaseUtcOffset);
            return roundViewModel;
        }

        protected virtual FilterDefinition<PlinkoGameRound> BuildRoundFilterExpression(long roundId)
        {
            var filter = Builders<PlinkoGameRound>.Filter.Eq(x => x.RoundId, roundId);
            return filter;
        }
    }
}