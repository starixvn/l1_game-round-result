using GameRoundResult.Core.Database.Entities.Player;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class RetrieveEndRoundInfoRequest : OperatorRequest, IRequest<EndRoundInfoResult>
    {
        public AuthModel Auth { get; set; }

        public long GameRoundId { get; set; }

        public int GameTypeId { get; set; }

        public string PlayerId { get; set; }

        public bool FreeBet { get; set; }
    }
}
