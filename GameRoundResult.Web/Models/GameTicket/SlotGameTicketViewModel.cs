using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using Sentry.Protocol;

namespace GameRoundResult.Web.Models
{
    public class SlotGameTicketViewModel : GameTicketViewModel
    {
        public SlotGameTicketViewModel(string configName, bool enabledJackpot, string systemType)
        {
            ConfigName = configName;
            EnabledJackpot = enabledJackpot;
            SystemType = systemType;
        }

        public string ConfigName { get; }

        public string SystemType { get; }

        public bool EnabledJackpot { get; }

        public SlotGameRoundResultViewModel RoundResult { get; set; }

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

    public class SlotGameRoundResultViewModel : RoundResultViewModel
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public IEnumerable<SlotGameBonusChestViewModel> BonusChests { get; set; }

        public SlotGameSettlementResultViewModel SettlementResult { get; set; }

        public decimal BetWin { get; set; }

        public byte[,] GetFormatResults()
        {
            var array = Result.ToArray();

            var formatResult = new byte[3, 5];

            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 5; column++)
                {
                    formatResult[row, column] = array[row + column * 3];
                }
            }

            return formatResult;
        }

        public decimal PickedBonusChestsTotalAmount => BonusChests.Where(x => x.Picked).Sum(x => x.Amount);

        public IEnumerable<byte> NotWinningPaylines => Paylines.Where(x => SettlementResult.WinningPaylines.All(y => y.Payline != x) && x != SettlementResult.Jackpot?.WinningLine);

        public decimal DisplayTotalAmount => FreeSpin ? 0 : TotalAmount;

        public decimal TotalBetWin => BetWin + (SettlementResult.Jackpot?.WinningAmount ?? 0);
    }

    public class SlotGameBonusChestViewModel
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class SlotGameSettlementResultViewModel
    {
        public IEnumerable<SlotGameWinningLineViewModel> WinningPaylines { get; set; }

        public SlotGameBonusViewModel Bonus { get; set; }

        public SlotGameFreeSpinViewModel FreeSpins { get; set; }

        public SlotGameJackpotViewModel Jackpot { get; set; }
    }

    public class SlotGameJackpotViewModel
    {
        public byte WinningLine { get; set; }

        public decimal WinningAmount { get; set; }
    }

    public class SlotGameWinningLineViewModel
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class SlotGameBonusViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class SlotGameFreeSpinViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}