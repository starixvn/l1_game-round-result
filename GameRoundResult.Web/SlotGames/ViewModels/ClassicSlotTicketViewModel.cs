using System;
using System.Globalization;
using System.Text;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.SlotGames.ViewModels
{
    public class ClassicSlotTicketViewModel : GameTicketViewModel
    {
        private const string SymbolPrefix = "symbol";
        private const string PaylinePrefix = "payline";
        private const string JackpotSuffix = "jackpot";

        public ClassicSlotTicketViewModel(string configName, bool enabledJackpotConfig, string systemType)
        {
            ConfigName = configName;
            EnableJackpotConfig = enabledJackpotConfig;
            SystemType = systemType;
        }

        public string ConfigName { get; }

        public string SystemType { get; }

        public bool EnableJackpotConfig { get; }

        public bool EnabledJackpot => EnableJackpotConfig
            && (GameId == (int)Core.Constants.GameType.FourGuardians || RoundResult?.JackpotContribution != null);

        public ClassicSlotRoundResultViewModel RoundResult { get; set; }

        public new decimal WinLoss => RoundResult.FreeSpin ? RoundResult.TotalBetWin : RoundResult.TotalBetWin - RoundResult.TotalAmount;

        public string DisplayWinLoss => WinLoss.Format();

        private string SymbolImageName(string symbol)
        => IsJackpotSymbol(byte.Parse(symbol)) ? GetJackpotSymbolName() : $"{SymbolPrefix}-{symbol}";

        public Uri GetSymbolUrl(string symbol)
        => new($"{StaticResourceUrl}/{ConfigName}/{SymbolImageName(symbol)}.png");

        public Uri GetSymbolUrl(byte symbol)
        => GetSymbolUrl(symbol.ToString());

        public Uri GetPaylineUrl(byte payline)
        => new($"{StaticResourceUrl}/_shared/classicslot/{PaylinePrefix}-{payline + 1}.png");

        public bool IsJackpotSymbol(byte number) =>
            number == SlotGameConstant.JackpotSymbol && EnabledJackpot;

        public static string GetJackpotSymbolName()
        {
            var jackpotSymbol = new StringBuilder($"{SymbolPrefix}-{SlotGameConstant.JackpotSymbol}.{JackpotSuffix}");

            if (CultureInfo.CurrentUICulture.Name == "vi-VN")
            {
                jackpotSymbol.Append(".vi-VN");
            }

            return jackpotSymbol.ToString();
        }

        public bool HasBonus => RoundResult.SettlementResult.Bonus.Odds > 0;

        public bool HasFreeSpins => RoundResult.SettlementResult.FreeSpins.Odds > 0;

        public bool HasData => RoundResult != null;

        public string FreeSpinsLabel => RoundResult.FreeSpin ? "Free Spins" : string.Empty;

        public bool HasJackpot => RoundResult.SettlementResult.Jackpot != null;

        public bool IsLose => WinLoss < 0;
    }
}