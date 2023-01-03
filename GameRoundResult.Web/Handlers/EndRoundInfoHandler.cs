using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Services;
using MediatR;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class EndRoundInfoHandler : IRequestHandler<Requests.RetrieveEndRoundInfoRequest, EndRoundInfoResult>
    {
        private readonly IEndGameInfoServiceFactory factory;
        private readonly IValidator<Requests.RetrieveEndRoundInfoRequest> validator;

        public EndRoundInfoHandler(
            IEndGameInfoServiceFactory factory,
            IValidator<Requests.RetrieveEndRoundInfoRequest> validator)
        {
            this.factory = factory;
            this.validator = validator;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
            IEndGameInfoService service;

            try
            {
                var validatorResult = validator.Validate(request);

                if (validatorResult.IsValid)
                {
                    var gameType = Enum.Parse<GameType>(request.GameTypeId.ToString());

                    service = Enum.IsDefined(typeof(GameType), gameType) ? factory.GetService(gameType) : factory.GetSlotGameService();

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