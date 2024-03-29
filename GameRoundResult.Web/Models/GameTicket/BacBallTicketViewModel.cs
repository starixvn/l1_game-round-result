using GameRoundResult.Core.Database.Entities.BacBall;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class BacBallTicketViewModel : GameTicketViewModel
    {
        public long DrawId { get; set; }

        public BacBall1Round RoundResult { get; set; }

        public IEnumerable<TranslationBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public virtual bool IsWinningChoice(string displayedChoice)
        {
            var settlementResult = RoundResult.SettlementResult.FirstOrDefault(r => r.DrawId == DrawId);
            return bool.Parse(settlementResult.GetType().GetProperty(displayedChoice).GetValue(settlementResult, null).ToString());
        }

        public string GetRowBetClass(string displayedChoice)
        {
            return IsWinningChoice(displayedChoice) ? "bold text-blue" : string.Empty;
        }

        public decimal GetBetLogWin(TranslationBetLogViewModel bet)
        {
            if(IsWinningChoice("Tie") && (bet.ChoiceDisplay == "Player" || bet.ChoiceDisplay == "Banker"))
            {
                return bet.Amount;
            }
            else
            {
                return IsWinningChoice(bet.ChoiceDisplay) ? Odds[bet.Choice] * bet.Amount : 0;
            }
        }

        public int GetResultValue(string displayedChoice)
        {
            var result = RoundResult.Result.FirstOrDefault(r => r.DrawId == DrawId);
            return int.Parse(result.GetType().GetProperty(displayedChoice).GetValue(result, null).ToString());
        }
    }
}