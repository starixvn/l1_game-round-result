using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Web.Requests.RoundHistory;
using GameRoundResult.Web.RoundHistory;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Handlers
{
    public class RoundHistoryHandler : IRequestHandler<RoundHistoryRequest, RoundHistoryViewModel>        
    {
        private readonly IRoundHistoryAccessorFactory factory;
        private readonly IRoundHistoryAdditionalViewFactory additionalViewFactory;
        private readonly IGameManagementApi gameManagementApi;

        public RoundHistoryHandler(IRoundHistoryAccessorFactory factory, IRoundHistoryAdditionalViewFactory additionalViewFactory, IGameManagementApi gameManagementApi)
        {
            this.factory = factory;
            this.additionalViewFactory = additionalViewFactory;
            this.gameManagementApi = gameManagementApi;
        }

        public async Task<RoundHistoryViewModel> Handle(RoundHistoryRequest request, CancellationToken cancellationToken)
        {
            var response = await gameManagementApi.GetGameConfigById((int)request.Game);
            request.GameConfigs = response.Data;

            var accessor = factory.GetService(request.Game);

            if (accessor != null)
            {
                var result = await accessor.GetAsync(request);
                result.AdditionalViewName = additionalViewFactory.GetView(request.GameConfigs);
                return result;
            }

            throw new ArgumentException(nameof(request.Game));
        }        
    }
}
