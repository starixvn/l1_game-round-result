using System;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, GameTicketViewModel>
    {
        private readonly IGameTicketAccessorFactory serviceFactory;

        public GameTicketHandler(IGameTicketAccessorFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public async Task<GameTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            var service = serviceFactory.GetService(request.GameType);

            var gameTicket = await service.GetAsync(request);
            if (service != null)
            {
                var gameTicket = await service.GetAsync(request);

                if (gameTicket != null)
                {
                    gameTicket.TimeZoneOffset = request.TimeZoneInfo.GetUtcOffset(DateTimeOffset.UtcNow.AddMonths(7));
                }
                return gameTicket;
            }

            return null;
        }
    }
}