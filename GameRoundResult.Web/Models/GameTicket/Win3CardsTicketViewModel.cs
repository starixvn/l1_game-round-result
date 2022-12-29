using System.Collections.Generic;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    public class Win3CardsTicketViewModel : GameTicketViewModel
    {
        public Win3CardsRoundResultViewModel RoundResult { get; set; }
        public IEnumerable<Win3CardsBetLogViewModel> BetLogs { get; set; }
        public Dictionary<string, decimal> Odds { get; set; }

        public string GetBetLogWin(Win3CardsBetLogViewModel bet)
        {
            return RoundResult.IsWinningChoice(bet.ChoiceDisplay) ? (Odds[bet.Choice] * bet.Amount).Format() : "0";
        }

        public string GetRowBetClass(string choice)
        {
            return RoundResult.IsWinningChoice(choice) ? "bold" : string.Empty;
        }
    }

    public class Win3CardsBetLogViewModel : BetLogViewModel
    {
        public virtual string ChoiceDisplay => Choice == "dragon" ? "DragonWin3Cards" : char.ToUpper(Choice[0]) + Choice.Substring(1);
    }
}