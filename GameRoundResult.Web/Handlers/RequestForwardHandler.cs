using System;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class RequestForwardHandler
        : IRequestHandler<BetHistoryAccessUrlRequestModel, GameTicketAccessUrlResultModel>
    {
        private readonly IServiceProvider serviceProvider;

        public RequestForwardHandler(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<GameTicketAccessUrlResultModel> Handle(BetHistoryAccessUrlRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                request.CallFromCloudService = true;
                var cloudResultApi = this.serviceProvider.GetService<ICloudResultApi>();
                var hmacHelpers = this.serviceProvider.GetService<IHmacHelpers>();
                var accessKey = hmacHelpers.CreateAccessKey(request.Auth.OperatorSecret, request);
                var getAccessUrlResult = await cloudResultApi.GetAccessUrl(request, accessKey);

                getAccessUrlResult.IsAuthenticated = true;

                return getAccessUrlResult;
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
            }

            return new GameTicketAccessUrlResultModel { IsAuthenticated = false };
        }
    }
}