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
            if(request.GameType == Core.Constants.GameType.BacBall1)
            {
                return await GetBacBall1Async(request, utcDate);
            }
            else if (request.GameType == Core.Constants.GameType.BacBall2)
            {
                return await GetBacBall2Async(request, utcDate);
            }
            else
            {
                var result = await gameRoundResultService.GetGameRoundResultAsync<TRoundEntity>(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize);
                return (result.Item1, result.Item2.Select(x => x.ToViewModel<TRoundEntity, TRoundViewModel>(mapper, request.TimeZoneInfo)));
            }
        }

        private async Task<(long, IEnumerable<RoundResultViewModel>)> GetBacBall1Async(GetRoundResultRequest request, DateTime utcDate)
        {
            var result = await gameRoundResultService.GetBacBall1RoundResultAsync(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize);
            var roundResults = new List<BacBall1RoundResultViewModel>();
            foreach (var bacBallRound in result.Item2)
            {
                for (var i = bacBallRound.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == bacBallRound.Result[i].DrawId))
                    {
                        var roundResult = new BacBall1RoundResultViewModel
                        {
                            DrawId = bacBallRound.Result[i].DrawId,
                            Result = bacBallRound.Result[i],
                            SettlementResult = bacBallRound.SettlementResult[i],
                            Time = TimeZoneInfo.ConvertTimeFromUtc(bacBallRound.Time, request.TimeZoneInfo),
                            TimeZone = request.TimeZoneInfo
                        };
                        roundResults.Add(roundResult);
                    }
                }

            }

            return (result.Item1, roundResults);
        }

        private async Task<(long, IEnumerable<RoundResultViewModel>)> GetBacBall2Async(GetRoundResultRequest request, DateTime utcDate)
        {
            var result = await gameRoundResultService.GetBacBall2RoundResultAsync(utcDate, request.RoundId, (int)request.GameType, request.Page, request.PageSize);
            var roundResults = new List<BacBall2RoundResultViewModel>();
            foreach (var bacBallRound in result.Item2)
            {
                for (var i = bacBallRound.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == bacBallRound.Result[i].DrawId))
                    {
                        var roundResult = new BacBall2RoundResultViewModel
                        {
                            DrawId = bacBallRound.Result[i].DrawId,
                            Result = bacBallRound.Result[i],
                            SettlementResult = bacBallRound.SettlementResult[i],
                            Time = TimeZoneInfo.ConvertTimeFromUtc(bacBallRound.Time, request.TimeZoneInfo),
                            TimeZone = request.TimeZoneInfo
                        };
                        roundResults.Add(roundResult);
                    }
                }

            }

            return (result.Item1, roundResults);
        }
    }
}