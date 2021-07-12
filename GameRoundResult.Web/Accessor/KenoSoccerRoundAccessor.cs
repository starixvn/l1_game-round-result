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
    public class KenoSoccerRoundAccessor<TRoundEntity> : IGameRoundAccessor
        where TRoundEntity : KenoSoccerRound
    {
        private readonly IMapper mapper;
        private readonly IKenoSoccerRoundResultService gameRoundResultService;

        public KenoSoccerRoundAccessor(IKenoSoccerRoundResultService gameRoundResultService, IMapper mapper)
        {
            this.gameRoundResultService = gameRoundResultService;
            this.mapper = mapper;
        }
        
        public async Task<(long, IEnumerable<RoundResultViewModel>)> GetAsync(GetRoundResultRequest request)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);
            var result = await gameRoundResultService.GetGameRoundResultAsync<TRoundEntity>(utcDate, request.RoundId, request.Page, request.PageSize);

            return (result.Item1, result.Item2.Select(x => x.ToViewModel<TRoundEntity, KenoSoccerRoundResultViewModel>(mapper, request.TimeZoneInfo)));
        }
    }
}
