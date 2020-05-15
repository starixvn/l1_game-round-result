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
            switch (request.GameTypeId)
            {
                case (byte)GameType.BigSmall:
                    return (await gameRoundResultService.GetBigSmallRoundResultAsync(request.Date, request.RoundId))
                        .Select(x => x.ToViewModel());

                case (byte)GameType.BigSmallTurbo:
                    return (await gameRoundResultService.GetBigSmallTurboRoundResultAsync(request.Date, request.RoundId))
                        .Select(x => x.ToViewModel());

                case (byte)GameType.OddEven:
                    return (await gameRoundResultService.GetOddEvenRoundResultAsync(request.Date, request.RoundId))
                        .Select(x => x.ToViewModel());

                case (byte)GameType.OddEvenTurbo:
                    return (await gameRoundResultService.GetOddEvenTurboRoundResultAsync(request.Date, request.RoundId))
                        .Select(x => x.ToViewModel());

                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameTypeId));
            }
        }
    }
}