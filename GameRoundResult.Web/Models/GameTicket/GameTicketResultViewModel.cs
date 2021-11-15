using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketResultViewModel
    {
        public GameType GameType { get; set; }
        public GameTicketViewModel GameTicketResult { get; set; }
    }
}