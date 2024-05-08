using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Models
{
    public class LuckyNextTicketViewModel<Draw> : GameDrawTicketViewModel<Draw, LuckyNextRoundResult, LuckyNextSettlementResult>
        where Draw : LuckyNext1Round
    {
        public int GetResultValue()
        {
            return DrawResult.Ball;
        }
    }
}