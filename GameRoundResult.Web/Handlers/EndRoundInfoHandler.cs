using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class EndRoundInfoHandler : IRequestHandler<Requests.RetrieveEndRoundInfoRequest, EndRoundInfoResult>
    {
        private readonly IEndGameInfoServiceFactory factory;
        private readonly IValidator<Requests.RetrieveEndRoundInfoRequest> validator;
        private readonly IGameAdminApi gameAdminApi;
        private readonly IServiceProvider serviceProvider;
        private readonly CloudServiceConfig cloudServiceConfig;
        private readonly IPartnerService partnerService;

        public EndRoundInfoHandler(
            IEndGameInfoServiceFactory factory,
            IValidator<Requests.RetrieveEndRoundInfoRequest> validator,
            IGameAdminApi gameAdminApi,
            IServiceProvider serviceProvider,
            CloudServiceConfig cloudServiceConfig,
            IPartnerService partnerService)
        {
            this.factory = factory;
            this.validator = validator;
            this.gameAdminApi = gameAdminApi;
            this.serviceProvider = serviceProvider;
            this.cloudServiceConfig = cloudServiceConfig;
            this.partnerService = partnerService;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
            var @operator = await partnerService.Get(request.Auth?.OperatorId, request.Auth?.OperatorSecret);

            if(@operator == null)
            {
                return new EndRoundInfoResult { IsAuthenticated = false };
            }

            IEndGameInfoService service;

            try
            {
                SentrySdk.CaptureMessage(JsonConvert.SerializeObject(cloudServiceConfig) + JsonConvert.SerializeObject(request));

                if (cloudServiceConfig?.ShouldCallOnPremiseService((int)request.GameTypeId) == true)
                {
                    SentrySdk.CaptureMessage("Called Remote");
                    return await this.GetEndRoundInfoFromRemoteResultService(request);
                }

                var validatorResult = validator.Validate(request);

                if (validatorResult.IsValid)
                {
                    var gameConfigs = await gameAdminApi.GetGameConfigById(request.GameTypeId);

                    if (gameConfigs == null)
                    {
                        return EndRoundInfoError.SB1006;
                    }

                    var gameId = Enum.Parse<GameType>(request.GameTypeId.ToString());

                    service = factory.GetService(gameId, gameConfigs.Type);

                    return await service.GetAsync(new RetrieveEndGameInfoRequest
                    {
                        GameRoundId = request.GameRoundId,
                        GameTypeId = request.GameTypeId,
                        OperatorId = request.Auth.OperatorId,
                        PlayerId = request.PlayerId,
                        FreeBet = request.FreeBet,
                        GameName = gameConfigs.Name
                    });
                }

                var error = validatorResult.Errors.First();

                return new() { ErrorCode = error.ErrorCode, ErrorDescription = error.ErrorMessage };
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return EndRoundInfoError.SB1000;
            }
        }

        private async Task<EndRoundInfoResult> GetEndRoundInfoFromRemoteResultService(Requests.RetrieveEndRoundInfoRequest request)
        {
            try
            {
                var mainResultApi = this.serviceProvider.GetService<IMainResultApi>();

                var endRoundResult = await mainResultApi.RetrieveEndGameInfo(request);

                return endRoundResult;
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
            }

            return new EndRoundInfoResult { IsAuthenticated = false };
        }
    }
}