using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class FruitSlotTicketViewModel : GameTicketViewModel
    {
        public FruitSlotRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<FruitSlotBetLogViewModel> Bets { get; set; }
        public Dictionary<string, decimal> Odds { get; set; }
        public decimal TotalBet { get; set; }
        public decimal BetWin { get; set; }
        public decimal WinLoss => BetWin - TotalBet;

        public decimal GetOdds(IEnumerable<string> subChoices, string mainChoice)
        {
            var choice = GetOddsSubChoice(subChoices);
            return string.IsNullOrEmpty(choice) ? Odds[mainChoice] : Odds[choice];
        }

        public decimal GetBetWin(IEnumerable<string> subChoices, string mainChoice, decimal amount)
        {
            var choice = GetOddsSubChoice(subChoices);
            if (RoundResult.SettlementResult[mainChoice])
            {
                choice = mainChoice;
            }
            return string.IsNullOrEmpty(choice) ? 0 : Odds[choice] * amount;
        }

        private string GetOddsSubChoice(IEnumerable<string> subChoices)
        {
            var choice = string.Empty;
            foreach (var c in subChoices)
            {
                if (RoundResult.SettlementResult[c])
                {
                    choice = c;
                }
            }
            return choice;
        }
    }

    public class FruitSlotBetLogViewModel
    {
        public DateTime Time { get; set; }
        public string Choice { get; set; }
        public IEnumerable<string> SubChoices { get; set; }
        public decimal Amount { get; set; }
    }
}