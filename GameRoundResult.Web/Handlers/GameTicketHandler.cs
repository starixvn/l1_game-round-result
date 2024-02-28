using System;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, GameTicketViewModel>
    {
        private readonly IGameTicketAccessorFactory serviceFactory;
        private readonly IGameManagementApi gameManagementApi;

        public GameTicketHandler(IGameTicketAccessorFactory serviceFactory, IGameManagementApi gameManagementApi)
        {
            this.serviceFactory = serviceFactory;
            this.gameManagementApi = gameManagementApi;
        }

        public async Task<GameTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            var response = await gameManagementApi.GetGameConfigById((byte)request.GameId);

            if (response?.Data == null && string.IsNullOrWhiteSpace(response?.Data?.Name))
            {
                return null;
            }

            request.GameConfigs = response.Data;

            

            var service = serviceFactory.GetService(request.GameId, request.GameConfigs.Type);
            SentrySdk.CaptureMessage(string.Format("GameConfigs {0} {1}", Newtonsoft.Json.JsonConvert.SerializeObject(request.GameConfigs), service), Sentry.Protocol.SentryLevel.Error);

            var gameTicket = await service.GetAsync(request);

            if (gameTicket != null)
            {
                gameTicket.TimeZoneOffset = request.TimeZoneInfo.GetUtcOffset(DateTimeOffset.UtcNow);
            }

            return gameTicket;
        }
    }
}