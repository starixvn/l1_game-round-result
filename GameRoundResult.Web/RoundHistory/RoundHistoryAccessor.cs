using AutoMapper;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Core.RoundHistory.Entities;
using GameRoundResult.Core.RoundHistory.Models;
using GameRoundResult.Core.Services.RoundHistory;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Web.Requests.RoundHistory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace GameRoundResult.Web.RoundHistory
{
    public interface IRoundHistoryAccessor
    {
        Task<RoundHistoryViewModel> GetAsync(RoundHistoryRequest request);
    }

    public class RoundHistoryAccessor<TRoundEntity, TRoundViewModel, TBetEntity, TBetViewModel> : IRoundHistoryAccessor
        where TRoundEntity : RoundHistoryRoundEntity
        where TRoundViewModel : RoundResultViewModel
        where TBetEntity : RoundHistoryBetEntity, new()
        where TBetViewModel : RoundHistoryBetViewModel
    {
        private readonly IRoundHistoryService roundHistoryService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;        

        public RoundHistoryAccessor(IRoundHistoryService roundHistoryService, IMapper mapper, IConfiguration configuration)
        {
            this.roundHistoryService = roundHistoryService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<RoundHistoryViewModel> GetAsync(RoundHistoryRequest request)
        {
            var timeZone = TZConvert.GetTimeZoneInfo("SE Asia Standard Time");
            var roundResult = await roundHistoryService.GetRoundAsync<TRoundEntity>(request.RoundId, BuildRoundFilterExpression(request.RoundId));
            var betResult = await roundHistoryService.GetBetsAsync<TBetEntity>(request, BuildBetFilterExpression(request.RoundId));
            var betViewModel = betResult.Select(r => r.ToBetViewModel<TBetEntity, TBetViewModel>(mapper, timeZone));

            return new RoundHistoryViewModel
            {
                Round = MapRoundResult(roundResult, timeZone, request),
                Bets = betViewModel,
                Request = request,
                BaseCurrencyMultiplier = BaseCurrencyConfig.MultiplierMapper[configuration["SystemType"]],
                BaseCurrency = BaseCurrencyConfig.CurrencyMapper[configuration["SystemType"]]
            };
        }     

        protected virtual TRoundViewModel MapRoundResult(TRoundEntity roundResult, TimeZoneInfo timeZone, RoundHistoryRequest request)
        {
            var roundViewModel = roundResult?.ToViewModel<TRoundEntity, TRoundViewModel>(mapper, timeZone);
            return roundViewModel;
        }
        
        protected virtual FilterDefinition<TRoundEntity> BuildRoundFilterExpression(long roundId)
        {            
            var filter = Builders<TRoundEntity>.Filter.Eq(x => x.RoundId, roundId);
            return filter;
        }

        protected virtual Expression<Func<TBetEntity, bool>> BuildBetFilterExpression(long roundId)
        {
            Expression<Func<TBetEntity, bool>> expression = x => x.RoundId == roundId;
            return expression;
        }
    }
}
