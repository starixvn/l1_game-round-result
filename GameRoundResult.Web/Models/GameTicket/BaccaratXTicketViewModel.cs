using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("BaccaratX")]
    [ViewName("BaccaratXTicket")]
    public class BaccaratXTicketViewModel : GameTicketViewModel
    {
        private IEnumerable<string> RefundChoices { get; } = new[] { BaccaratBetChoice.Player, BaccaratBetChoice.Banker };
        public BaccaratXRoundResultViewModel RoundResult { get; set; }

        public IEnumerable<BaccaratXBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, IEnumerable<byte>> Multipliers { get; set; }
        public decimal Fee { get; set; }
        public decimal AmountExcludingFee { get; set; }
        public bool ReachMaxWin { get; set; }
        public bool ApplyMultiplier { get; set; }
        public string DisplayFee => DisplayAmount(Fee);
        public string DisplayAmountExcludingFee => DisplayAmount(AmountExcludingFee);
        public override string WinLossRowClassName => WinLoss < 0 ? "text-red" : "bet-win-text";

        public string DisplayMultipliersOnChoice(string choice)
        {
            if (Multipliers.ContainsKey(choice) && Multipliers[choice].Any())
            {
                return string.Join("x", Multipliers[choice]);
            }

            return "-";
        }

        public override bool IsWinningChoice(string choice)
        {
            return RoundResult.SettlementResult[choice];
        }

        public override string GetRowBetClass(string choice)
        {
            return IsWinningChoice(choice) || ShouldRefund(choice) ? "bold bet-win-text" : string.Empty;
        }

        public override decimal GetBetLogWin(BetLogViewModel betLog)
        {
            if (IsWinningChoice(betLog.Choice))
            {
                return betLog.Amount * CalculateFinalOdds(betLog.Choice);
            }

            if (ShouldRefund(betLog.Choice))
            {
                return betLog.Amount;
            }

            return 0;
        }

        private bool ShouldRefund(string choice)
            => RoundResult.SettlementResult[BaccaratBetChoice.Tie] && RefundChoices.Any(x => x == choice);

        private decimal CalculateFinalOdds(string choice)
        {
            if (Multipliers.ContainsKey(choice))
            {
                var odds = Odds[choice] - 1;

                foreach (var multiplier in Multipliers[choice])
                {
                    odds *= multiplier;
                }

                return odds + 1;
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

                return $"glossary_{choice}";
            }
        }
    }
}