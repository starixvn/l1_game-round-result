using System;
using System.Threading;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using MediatR;
using Sentry;

namespace GameRoundResult.Web.Handlers
{
    public class EndGameInfoHandler : IRequestHandler<Requests.RetrieveEndRoundInfoRequest, EndRoundInfoResult>
    {
        private readonly IEndGameInfoServiceFactory factory;

        public EndGameInfoHandler(IEndGameInfoServiceFactory factory)
        {
            this.factory = factory;
        }

        public async Task<EndRoundInfoResult> Handle(Requests.RetrieveEndRoundInfoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.GameRoundId == 0)
                {
                    return EndGameInfoError.SB1002;
                }

                if (string.IsNullOrWhiteSpace(request.SiteId))
                {
                    return EndGameInfoError.SB1003;
                }

                if (request.PlayerId == 0)
                {
                    return EndGameInfoError.SB1004;
                }

                if (!Enum.TryParse(request.GameTypeId.ToString(), out GameType gameType))
                {
                    return EndGameInfoError.SB1006;
                }

                var service = factory.GetService(gameType);
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
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return EndGameInfoError.SB1000;
            }
        }
    }
}