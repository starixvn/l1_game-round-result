using AutoMapper;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Services.RoundHistory;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Web.Requests;
using GameRoundResult.Web.Requests.RoundHistory;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameRoundResult.Web.RoundHistory
{
    public class DrawRoundHistoryAccessor<TRoundEntity, TRoundViewModel, TBetEntity, TBetViewModel, TResult, TSettlementResult> : RoundHistoryAccessor<TRoundEntity, TRoundViewModel, TBetEntity, TBetViewModel>
        where TResult : GameDrawBase
        where TRoundEntity : GameDraw<TResult, TSettlementResult>
        where TRoundViewModel : RoundResultViewModel
        where TBetEntity : GameDrawBaseBetEntity, new()
        where TBetViewModel : RoundHistoryBetViewModel
    {
        public DrawRoundHistoryAccessor(IRoundHistoryService roundHistoryService, IMapper mapper, IConfiguration configuration) : base(roundHistoryService, mapper, configuration)
        {
        }

        protected override TRoundViewModel MapRoundResult(TRoundEntity roundResult, TimeZoneInfo timeZone, RoundHistoryRequest request)
        {
            if (roundResult != null)
            {
                GetRoundResultRequest getRequest = new GetRoundResultRequest(request.Game, DateTime.Now, request.RoundId, timeZone, 1, 1);
                var roundResults = GameDrawTicketAccessorHelper.GetRoundResult(getRequest, new List<TRoundEntity> { roundResult });
                var viewModel = (TRoundViewModel)roundResults.First();
                viewModel.ExchangeRateId = roundResult.ExchangeRateId;

                return viewModel;
            }
            else
            {
                return null;
            }
        }

        protected override FilterDefinition<TRoundEntity> BuildRoundFilterExpression(long roundId)
        {
            var filter = Builders<TRoundEntity>.Filter.ElemMatch(x => x.Result, y => y.DrawId == roundId);
            return filter;
        }

        protected override Expression<Func<TBetEntity, bool>> BuildBetFilterExpression(long roundId)
        {
            Expression<Func<TBetEntity, bool>> expression = x => x.DrawId == roundId;
            return expression;
        }
    }
}