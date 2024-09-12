using GameRoundResult.Core.Models.RoundHistory;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.RoundHistory;
using MediatR;

namespace GameRoundResult.Web.Requests.RoundHistory
{
    public class RoundHistoryRequest : RoundHistoryRequestBase, IRequest<RoundHistoryViewModel>
    {
        public AuthModel Auth { get; set; }
        public GameConfigModel GameConfigs { get; set; }
    }
}
