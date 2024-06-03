using System.Collections.Generic;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("Bac81")]
    public class BaccaratXTicketViewModel : GameTicketViewModel
    {
        public BaccaratXRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BaccaratXBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, IEnumerable<byte>> Multipliers { get; set; }
        public decimal Fee { get; set; }

        public string DisplayFee => DisplayAmount(Fee);

        public string DisplayMultipliersOnChoice(string choice)
        {
            if (Multipliers.ContainsKey(choice))
            {
                return string.Join("x", Multipliers[choice]);
            }

            return "-";
        }

        public override bool IsWinningChoice(string choice)
        {
            return RoundResult.SettlementResult[choice];
        }

        public override decimal GetBetLogWin(BetLogViewModel betLog)
        {
            if (IsWinningChoice(betLog.Choice))
            {
                return betLog.Amount * CalculateFinalOdds(betLog.Choice);
            }

            return 0;
        }

        private decimal CalculateFinalOdds(string choice)
        {
            if (Multipliers.ContainsKey(choice))
            {
                var odds = Odds[choice];

                foreach (var multiplier in Multipliers[choice])
                {
                    odds *= multiplier;
                }

                return odds;
            }

            return Odds[choice];
        }
    }

    public class BaccaratXBetLogViewModel : BetLogViewModel
    {
        public decimal Fee { get; set; }
        public string DisplayFee => Fee.Format();

        public override string ChoiceKey
        {
            get
            {
                var choice = Choice;

                if (Choice == "playerPair")
                {
                    choice = "player_pair";
                }

                if (Choice == "bankerPair")
                {
                    choice = "banker_pair";
                }

                return $"glossary_option_{choice}";
            }
        }
    }
}