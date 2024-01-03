using GameRoundResult.Core.Database.Entities.Player;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class RetrieveEndRoundInfoRequest : OperatorRequest, IRequest<EndRoundInfoResult>
    {
        public AuthModel Auth { get; set; }

        public int GameRoundId { get; set; }

        public byte GameTypeId { get; set; }

        public int PlayerId { get; set; }

        public bool FreeBet { get; set; }
    }
}
