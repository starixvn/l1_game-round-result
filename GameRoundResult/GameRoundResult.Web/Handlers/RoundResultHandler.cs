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
    public class RoundResultHandler : IRequestHandler<GetRoundResultRequest, IEnumerable<RoundResultViewModel>>
    {
        private readonly IGameRoundResultService gameRoundResultService;

        public RoundResultHandler(IGameRoundResultService gameRoundResultService)
        {
            this.gameRoundResultService = gameRoundResultService;
        }

        public async Task<IEnumerable<RoundResultViewModel>> Handle(GetRoundResultRequest request, CancellationToken cancellationToken)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);

            switch (request.GameType)
            {
                case GameType.BigSmall:
                    return (await gameRoundResultService.GetBigSmallRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.BigSmallTurbo:
                    return (await gameRoundResultService.GetBigSmallTurboRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.OddEven:
                    return (await gameRoundResultService.GetOddEvenRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.OddEvenTurbo:
                    return (await gameRoundResultService.GetOddEvenTurboRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.ShakeThePlate:
                    return (await gameRoundResultService.GetShakeThePlateRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.FishPrawn:
                    return (await gameRoundResultService.GetFishPrawnRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                case GameType.DragonTiger:
                    return (await gameRoundResultService.GetDragonTigerRoundResultAsync(utcDate, request.RoundId))
                        .Select(x => x.ToViewModel(request.TimeZoneInfo));

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
            }
        }
    }
}