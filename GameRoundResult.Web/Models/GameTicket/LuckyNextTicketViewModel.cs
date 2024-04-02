using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Models
{
    public class LuckyNextTicketViewModel : GameDrawTicketViewModel<LuckyNext1Round, LuckyNextRoundResult, LuckyNextSettlementResult>
    {
        public int GetResultValue()
        {
            return DrawResult.Ball;
        }
    }
}