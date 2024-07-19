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
            var response = await gameManagementApi.GetGameConfigById((int)request.GameId);

            if (response?.Data == null && string.IsNullOrWhiteSpace(response?.Data?.Name))
            {
                return null;
            }

            request.GameConfigs = response.Data;

            var service = serviceFactory.GetService(request.GameId, request.GameConfigs.Type);
            var gameTicket = await service.GetAsync(request);

            if (gameTicket != null)
            {
                gameTicket.TimeZoneOffset = request.TimeZoneOffset;
                gameTicket.GameDisplayName = request.GameConfigs.DisplayName;
            }

            return gameTicket;
        }
    }
}