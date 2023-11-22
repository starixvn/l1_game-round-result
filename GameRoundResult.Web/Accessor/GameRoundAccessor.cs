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

        public GameRoundAccessor(IGameRoundResultService gameRoundResultService, IMapper mapper)
        {
            this.gameRoundResultService = gameRoundResultService;
            this.mapper = mapper;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> GetAsync(GetRoundResultRequest request)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);
            var result = await gameRoundResultService.GetGameRoundResultAsync<TRoundEntity>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize);
           
            return (result.Item1, result.Item2.Select(x => x.ToViewModel<TRoundEntity, TRoundViewModel>(mapper, request.TimeZoneInfo)));
        }
    }
}