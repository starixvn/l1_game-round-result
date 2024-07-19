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

        public RoundHistoryHandler(IRoundHistoryAccessorFactory factory, IRoundHistoryAdditionalViewFactory additionalViewFactory)
        {
            this.factory = factory;
            this.additionalViewFactory = additionalViewFactory;
        }

        public async Task<RoundHistoryViewModel> Handle(RoundHistoryRequest request, CancellationToken cancellationToken)
        {
            var accessor = factory.GetService(request.Game);

            if (accessor != null)
            {
                var result = await accessor.GetAsync(request);
                result.AdditionalViewName = additionalViewFactory.GetView(request.Game);
                return result;
            }

            throw new ArgumentException(nameof(request.Game));
        }        
    }
}
