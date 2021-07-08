using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class RoundResultHandler : IRequestHandler<GetRoundResultRequest, (long, IEnumerable<RoundResultViewModel>)>
    {
        private readonly IGameRoundAccessorFactory factory;

        public RoundResultHandler(IGameRoundAccessorFactory factory)
        {
            this.factory = factory;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> Handle(GetRoundResultRequest request, CancellationToken cancellationToken)
        {
            var accessor = factory.GetService(request.GameType);

            if (accessor != null)
            {
                return await accessor.GetAsync(request);
            }

            throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
        }
    }
}