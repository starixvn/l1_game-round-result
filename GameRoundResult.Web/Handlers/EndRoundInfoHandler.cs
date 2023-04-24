using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Services;
using MediatR;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class EndRoundInfoHandler : IRequestHandler<Requests.RetrieveEndRoundInfoRequest, EndRoundInfoResult>
    {
        private readonly IEndGameInfoServiceFactory factory;
        private readonly IValidator<Requests.RetrieveEndRoundInfoRequest> validator;
        private readonly IGameAdminApi gameAdminApi;

        public EndRoundInfoHandler(
            IEndGameInfoServiceFactory factory,
            IValidator<Requests.RetrieveEndRoundInfoRequest> validator,
            IGameAdminApi gameAdminApi)
        {
            this.factory = factory;
            this.validator = validator;
            this.gameAdminApi = gameAdminApi;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
            IEndGameInfoService service;

            try
            {
                var validatorResult = validator.Validate(request);

                if (validatorResult.IsValid)
                {
                    var gameConfigs = await gameAdminApi.GetGameConfigById(request.GameTypeId);

                    if (gameConfigs == null)
                    {
                        return EndRoundInfoError.SB1006;
                    }

                    var gameId = Enum.Parse<GameId>(request.GameTypeId.ToString());

                    service = factory.GetService(gameId, gameConfigs.Type);

                    return await service.GetAsync(new RetrieveEndGameInfoRequest
                    {
                        GameRoundId = request.GameRoundId,
                        GameTypeId = request.GameTypeId,
                        OperatorId = request.Auth.OperatorId,
                        PlayerId = request.PlayerId,
                        SiteId = request.SiteId,
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
    }
}