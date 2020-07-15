using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketSearchViewModel
    {
        public GameType GameType { get; set; }
        public GameTicketViewModel GameTicketResult { get; set; }
    }
}