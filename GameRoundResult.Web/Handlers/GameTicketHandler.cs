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

            return await service.GetAsync(request);

                case GameType.HeroesSlot:
                    var heroesSlotResult = await service.GetHeroesSlotAsync(request.RoundId, request.MemberId);
                    return new HeroesSlotTicketViewModel
                    {
                        RoundResult = heroesSlotResult?.ToViewModel(mapper, request.TimeZoneInfo),
                    };
        }
    }
}