using System.Collections.Generic;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    public class CoinTossTicketViewModel : GameTicketViewModel
    {
        public CoinTossRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BetLogViewModel> BetLogs { get; set; }

        public override bool IsWinningChoice(string choice)
        {
            return choice.ToLower() == "head" ? RoundResult.SettlementResult.Head : RoundResult.SettlementResult.Tail;
        }

        protected override string GetChoice(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer, string choice)
        {
            return RoundResult.GetText(stringLocalizer, choice);
        }

        public override IEnumerable<string> BuildBetLogs(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            var result = new List<string>();
            foreach (var bet in BetLogs)
            {
                result.Add(BuildRow(stringLocalizer, bet));
            }

            return result;
        }
    }
}