using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Core.Database.Repository.RoundHistory;
using GameRoundResult.Core.Models.RoundHistory;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services.RoundHistory
{
    public interface IRoundHistoryService
    {
        Task<TRound> GetRoundAsync<TRound>(long roundId, FilterDefinition<TRound> baseFilterExpression) where TRound : GameRound;

        Task<IEnumerable<TBetEntity>> GetBetsAsync<TBetEntity>(RoundHistoryRequestBase filter, FilterDefinition<TBetEntity> baseFilterExpression)
            where TBetEntity : RoundHistoryBetEntity, new();
    }

    public class RoundHistoryService : IRoundHistoryService
    {
        private readonly IRoundHistoryRepository roundHistoryRepository;
        protected readonly IUserInfoService userInfoService;
        protected readonly IPartnerService partnerService;

        public RoundHistoryService(IRoundHistoryRepository roundHistoryRepository, IUserInfoService userInfoService, IPartnerService partnerService)
        {
            this.roundHistoryRepository = roundHistoryRepository;
            this.userInfoService = userInfoService;
            this.partnerService = partnerService;
        }

        public Task<TRound> GetRoundAsync<TRound>(long roundId, FilterDefinition<TRound> baseFilterExpression) where TRound : GameRound
        {
            return roundHistoryRepository.GetRoundAsync<TRound>(roundId, baseFilterExpression);
        }

        public async Task<IEnumerable<TBetEntity>> GetBetsAsync<TBetEntity>(RoundHistoryRequestBase filter, FilterDefinition<TBetEntity> baseFilterExpression)
            where TBetEntity : RoundHistoryBetEntity, new()
        {
            var bets = await roundHistoryRepository.GetBetsAsync<TBetEntity>(filter, baseFilterExpression);
            var betsWithUserInfo = await GetBetRecordsWithUserInfo(bets, filter.Username, filter.ExcludeBot);

            return betsWithUserInfo;
        }

        protected async Task<IEnumerable<TBetRecord>> GetBetRecordsWithUserInfo<TBetRecord>(IEnumerable<TBetRecord> bets, string username, bool excludeBot)
            where TBetRecord : RoundHistoryBetEntity
        {
            if (bets.Any())
            {
                var userInfos = await userInfoService.FilterByUidsAndUserName(bets.Select(x => x.Uid), username, excludeBot);

                return bets.Join(userInfos, bet => bet.Uid, userInfo => userInfo.Uid, (bet, userInfo) =>
                {
                    bet.Username = userInfo.Username;
                    bet.Nickname = userInfo.NickName;
                    bet.OperatorName = partnerService.GetById(bet.OperatorId).Result.Name;
                    return bet;
                }).ToList();
            }

            return Enumerable.Empty<TBetRecord>();
        }
    }
}