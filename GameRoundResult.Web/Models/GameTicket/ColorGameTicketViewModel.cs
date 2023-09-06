using GameRoundResult.Web.Configuration;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class ColorGameTicketViewModel : GameTicketViewModel
    {
        public ColorGameRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<ColorGameBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public List<string> BetChoices => new List<string> { "Dragon", "Tiger", "Tie", "BlackDragon", "RedDragon", "BlackTiger", "RedTiger" };

        public string GetRowBetClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold text-blue" : string.Empty;
        }

        public string GetValueClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold" : string.Empty;
        }

        public string GetWinningOddName(string choice)
        {
            var isWin = this.RoundResult.SettlementResult[choice.ToLower()];
            var resultMapper = new Dictionary<string, int>() { { "yellow", 0 }, { "red", 1 }, { "pink", 2 }, { "white", 3 }, { "blue", 4 }, { "green", 5 } };
            var oddMapper = new Dictionary<int, string>() { { 1, "single" }, { 2, "double" }, { 3, "triple" } };

            if (this.RoundResult.InferableChoices.Contains(choice) && isWin)
            {
                return choice;
            }
            else if (isWin)
            {
                var winCount = 0;
                if (this.RoundResult.Result.Dice1 == resultMapper[choice])
                {
                    winCount += 1;
                }
                if (this.RoundResult.Result.Dice2 == resultMapper[choice])
                {
                    winCount += 1;
                }
                if (this.RoundResult.Result.Dice3 == resultMapper[choice])
                {
                    winCount += 1;
                }
                return oddMapper[winCount];
            }
            else
            {
                return string.Empty;
            }
        }

        public decimal GetOdds(string choice)
        {
            var winningOddsName = GetWinningOddName(choice);
            if (string.IsNullOrEmpty(winningOddsName))
            {
                return 0;
            }
            else
            {
                return Odds[winningOddsName];
            }
        }

        public decimal  GetBetLogWin(ColorGameBetLogViewModel bet)
        {            
            return GetOdds(bet.Choice) * bet.Amount;            
        }
    }

    public class ColorGameBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => char.ToUpper(Choice[0]) + Choice.Substring(1);

        public string TolgeeChoiceKey => "glossary_" + Choice;
    }
}