using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class KenoMatchRoundAccessor<TRoundEntity> : IGameRoundAccessor
        where TRoundEntity : KenoMatchRound
    {
        private readonly IMapper mapper;
        private readonly IKenoMatchRoundResultService gameRoundResultService;

        public KenoMatchRoundAccessor(IKenoMatchRoundResultService gameRoundResultService, IMapper mapper)
        {
            this.gameRoundResultService = gameRoundResultService;
            this.mapper = mapper;
        }
        
        public async Task<(long, IEnumerable<RoundResultViewModel>)> GetAsync(GetRoundResultRequest request)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);
            var result = await gameRoundResultService.GetGameRoundResultAsync<TRoundEntity>(utcDate, request.RoundId, request.Page, request.PageSize);

            return (result.Item1, result.Item2.Select(x => x.ToViewModel<TRoundEntity, KenoMatchRoundResultViewModel>(mapper, request.TimeZoneInfo.BaseUtcOffset)));
        }
    }
}
