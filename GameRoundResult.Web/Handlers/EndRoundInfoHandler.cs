using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Validators;
using MediatR;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class EndRoundInfoHandler : IRequestHandler<Requests.RetrieveEndRoundInfoRequest, EndRoundInfoResult>
    {
        private readonly IEndGameInfoServiceFactory factory;

        public EndRoundInfoHandler(IEndGameInfoServiceFactory factory)
        {
            this.factory = factory;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new RetrieveEndRoundInfoRequestValidator();
                var validatorResult = validator.Validate(request);

                if (validatorResult.IsValid)
                {
                    var gameType = Enum.Parse<GameType>(request.GameTypeId.ToString());
                    IEndGameInfoService service;

                    if (Enum.IsDefined(typeof(GameType), gameType))
                    {
                        service = factory.GetService(gameType);
                    }
                    else
                    {
                        service = factory.GetSlotGameService();
                    }

                    return await service.GetAsync(new RetrieveEndGameInfoRequest
                    {
                        GameRoundId = request.GameRoundId,
                        GameTypeId = request.GameTypeId,
                        OperatorId = request.Auth.OperatorId,
                        PlayerId = request.PlayerId,
                        SiteId = request.SiteId,
                        FreeBet = request.FreeBet
                    });
                }

                var error = validatorResult.Errors.FirstOrDefault();

                return new()
                {
                    ErrorCode = error.ErrorCode,
                    ErrorDescription = error.ErrorMessage,
                };
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return EndRoundInfoError.SB1000;
            }
        }
    }
}