using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class RoundResultHandler : IRequestHandler<GetRoundResultRequest, (long, IEnumerable<RoundResultViewModel>)>
    {
        private readonly IGameRoundAccessorFactory factory;
        private readonly IGeneralGameSettingService generalGameSettingService;

        public RoundResultHandler(IGameRoundAccessorFactory factory, IGeneralGameSettingService generalGameSettingService)
        {
            this.factory = factory;
            this.generalGameSettingService = generalGameSettingService;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> Handle(GetRoundResultRequest request, CancellationToken cancellationToken)
        {
            var isCrashGame = await generalGameSettingService.IsCrashGame((int)request.GameType);
            var accessor = factory.GetService(request.GameType, isCrashGame);

            if (accessor != null)
            {
                return await accessor.GetAsync(request);
            }

            throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
        }
    }
}