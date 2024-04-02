using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Models
{
    public class BacBallTicketViewModel<Draw>: GameDrawTicketViewModel<Draw, BacBallRoundResult, BacBallSettlementResult>
        where Draw : BacBall1Round
    {
        public override decimal GetBetLogWin(TranslationBetLogViewModel bet)
        {
            if (IsWinningChoice("Tie") && (bet.ChoiceDisplay == "Player" || bet.ChoiceDisplay == "Banker"))
            {
                return bet.Amount;
            }
            else
            {
                return base.GetBetLogWin(bet);
            }
        }

        public int GetResultValue(string displayedChoice)
        {
            return int.Parse(DrawResult.GetType().GetProperty(displayedChoice).GetValue(DrawResult, null).ToString());
        }
    }
}