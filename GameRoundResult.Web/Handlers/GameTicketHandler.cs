using System;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, GameTicketViewModel>
    {
        private readonly IGameTicketAccessorFactory serviceFactory;
        private readonly IGameAdminApi gameAdminApi;

        public GameTicketHandler(IGameTicketAccessorFactory serviceFactory, IGameAdminApi gameAdminApi)
        {
            this.serviceFactory = serviceFactory;
            this.gameAdminApi = gameAdminApi;
        }

        public async Task<GameTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            var gameConfigs = await gameAdminApi.GetGameConfigById((byte)request.GameId);

            if (gameConfigs == null)
            {
                return null;
            }

            var service = serviceFactory.GetService(request.GameId, gameConfigs.Type);

            var gameTicket = await service.GetAsync(request, gameConfigs);

            if (gameTicket != null)
            {
                gameTicket.TimeZoneOffset = request.TimeZoneInfo.GetUtcOffset(DateTimeOffset.UtcNow);
            }

            return gameTicket;
        }
    }
}