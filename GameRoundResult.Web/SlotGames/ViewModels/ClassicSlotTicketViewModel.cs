using System.Globalization;
using System.Text;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.SlotGames.ViewModels;

namespace GameRoundResult.Web.Models
{
    public class ClassicSlotTicketViewModel : GameTicketViewModel
    {
        public ClassicSlotTicketViewModel(string configName, bool enabledJackpot, string systemType)
        {
            ConfigName = configName;
            EnabledJackpot = enabledJackpot;
            SystemType = systemType;
        }

        public string ConfigName { get; }

        public string SystemType { get; }

        public bool EnabledJackpot { get; }

        public ClassicSlotRoundResultViewModel RoundResult { get; set; }

        //TODO remove that
        public decimal BetWin => RoundResult.BetWin + (RoundResult.SettlementResult.Jackpot?.WinningAmount ?? 0);

        //TODO it should be in RoundResultViewModel
        public decimal WinLoss => RoundResult.FreeSpin ? RoundResult.TotalBetWin : RoundResult.TotalBetWin - RoundResult.TotalAmount;

        public string SymbolImageName(string symbol)
        => IsJackpotSymbol(byte.Parse(symbol)) ? GetJackpotSymbolFile() : symbol;

        public bool IsJackpotSymbol(byte number) => number == SlotGameConstant.JackpotSymbol && EnabledJackpot;

        public static string GetJackpotSymbolFile()
        {
            var jackpotSymbol = new StringBuilder($"{SlotGameConstant.JackpotSymbol}.jackpot");

            if (CultureInfo.CurrentUICulture.Name == "vi-VN")
            {
                jackpotSymbol.Append(".vi-VN");
            }

            return jackpotSymbol.ToString();
        }

        public bool HasBonus => RoundResult.SettlementResult.Bonus.Odds > 0;

        public bool HasFreeSpins => RoundResult.SettlementResult.FreeSpins.Odds > 0;

        public bool HasData => RoundResult != null;

        public string FreeSpinsLabel => HasFreeSpins ? "Free Spins" : string.Empty;

        public bool HasJackpot => RoundResult.SettlementResult.Jackpot != null;
    }
}