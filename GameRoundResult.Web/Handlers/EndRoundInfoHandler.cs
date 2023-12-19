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
        private readonly IGameManagementApi gameManagementApi;
        private readonly IServiceProvider serviceProvider;
        private readonly CloudServiceConfig cloudServiceConfig;
        private readonly IPartnerService partnerService;

        public EndRoundInfoHandler(
            IEndGameInfoServiceFactory factory,
            IValidator<Requests.RetrieveEndRoundInfoRequest> validator,
            IGameManagementApi gameManagementApi,
            IServiceProvider serviceProvider,
            CloudServiceConfig cloudServiceConfig,
            IPartnerService partnerService)
        {
            this.factory = factory;
            this.validator = validator;
            this.gameManagementApi = gameManagementApi;
            this.serviceProvider = serviceProvider;
            this.cloudServiceConfig = cloudServiceConfig;
            this.partnerService = partnerService;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
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
                    var response = await gameManagementApi.GetGameConfigById(request.GameTypeId);

                    if (response?.Data == null || string.IsNullOrWhiteSpace(response?.Data.Name))
                    {
                        return EndRoundInfoError.SB1006;
                    }

                    var gameConfigs = response.Data;

                    var gameId = Enum.Parse<GameType>(request.GameTypeId.ToString());

                    IEndGameInfoService service = factory.GetService(gameId, gameConfigs.Type);

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