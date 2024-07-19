using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameRoundAccessor
    {
        Task<(long, IEnumerable<RoundResultViewModel>)> GetAsync(GetRoundResultRequest request);
    }

    public class GameRoundAccessor<TRoundEntity, TRoundViewModel> : IGameRoundAccessor
        where TRoundEntity : GameRound
        where TRoundViewModel : RoundResultViewModel
    {
        private readonly IMapper mapper;
        private readonly IGameRoundResultService gameRoundResultService;
        private readonly IGameDrawTypeFactory gameDrawTypeFactory;

        public GameRoundAccessor(IGameRoundResultService gameRoundResultService, IMapper mapper, IGameDrawTypeFactory gameDrawTypeFactory)
        {
            this.gameRoundResultService = gameRoundResultService;
            this.mapper = mapper;
            this.gameDrawTypeFactory = gameDrawTypeFactory;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> GetAsync(GetRoundResultRequest request)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);

            if (request.IsGameDraw)
            {
                return await GetGameDrawAsync(request, utcDate);
            }
            else
            {
                var result = await gameRoundResultService.GetGameRoundResultAsync<TRoundEntity>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize);
                return (result.Item1, result.Item2.Select(x => x.ToViewModel<TRoundEntity, TRoundViewModel>(mapper, request.TimeZoneInfo.BaseUtcOffset)));
            }
        }

        private async Task<(long, IEnumerable<RoundResultViewModel>)> GetGameDrawAsync(GetRoundResultRequest request, DateTime utcDate)
        {
            var result = await gameDrawTypeFactory.GetGameDrawType(request, utcDate);
            var roundResults = GameDrawTicketAccessorHelper.GetRoundResult(request,result.Item2);
            return (result.Item1, roundResults);
        }
    }
}