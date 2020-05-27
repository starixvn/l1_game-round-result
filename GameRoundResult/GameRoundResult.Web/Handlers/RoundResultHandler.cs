using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class RoundResultHandler : IRequestHandler<GetRoundResultRequest, (long, IEnumerable<RoundResultViewModel>)>
    {
        private readonly IGameRoundResultService gameRoundResultService;

        public RoundResultHandler(IGameRoundResultService gameRoundResultService)
        {
            this.gameRoundResultService = gameRoundResultService;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> Handle(GetRoundResultRequest request, CancellationToken cancellationToken)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);

            switch (request.GameType)
            {
                case GameType.BigSmall:
                    var bigSmallResult = await gameRoundResultService.GetBigSmallRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (bigSmallResult.Item1, bigSmallResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.BigSmallTurbo:
                    var bigSmallTurbo = await gameRoundResultService.GetBigSmallTurboRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (bigSmallTurbo.Item1, bigSmallTurbo.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.OddEven:
                    var oddEvenResult = await gameRoundResultService.GetOddEvenRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (oddEvenResult.Item1, oddEvenResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.OddEvenTurbo:
                    var oddEvenTurboResult = await gameRoundResultService.GetOddEvenTurboRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (oddEvenTurboResult.Item1, oddEvenTurboResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.ShakeThePlate:
                    var shakeThePlateResult = await gameRoundResultService.GetShakeThePlateRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (shakeThePlateResult.Item1, shakeThePlateResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.FishPrawn:
                    var fishPrawnResult = await gameRoundResultService.GetFishPrawnRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (fishPrawnResult.Item1, fishPrawnResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.DragonTiger:
                    var dragonTigerResult = await gameRoundResultService.GetDragonTigerRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (dragonTigerResult.Item1, dragonTigerResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                case GameType.KenoProMax:
                    var kenoResult = await gameRoundResultService.GetKenoProMaxRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoResult.Item1, kenoResult.Item2.Select(x => x.ToViewModel(request.TimeZoneInfo)));

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
            }
        }
    }
}