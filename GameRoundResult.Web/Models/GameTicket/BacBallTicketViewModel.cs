using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models.GameTicket;
using System.Collections.Generic;

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

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, bool convertToUSD = false, int baseCurrencyMultiplier = 1)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs)
            {
                result.Add(BuildRow(stringLocalizer, bet, convertToUSD, baseCurrencyMultiplier));
            }

            return result;
        }
      
        public override decimal GetBetLogWin(BetLogViewModel bet)
        {
            return IsWinningChoice(bet.DisplayedChoice) ? Odds[bet.Choice] * bet.Amount : 0;
        }

        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            return GetText(stringLocalizer, choice);
        }

        protected override decimal GetOdds(string choice)
        {
            return Odds[choice];
        }

        protected string GetText(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string key)
        {
            var betChoice = new BetLogViewModel { Choice = key };
            return stringLocalizer.GetStringWithNamcespace(betChoice.ChoiceKey, "BacBall");
        }
    }
}