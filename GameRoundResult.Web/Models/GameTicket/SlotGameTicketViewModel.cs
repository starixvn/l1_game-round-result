using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class SlotGameTicketViewModel : GameTicketViewModel
    {
        public string ConfigName { get; set; }

        public SlotGameRoundResultViewModel RoundResult { get; set; }

        public decimal BetWin => RoundResult.BetWin + (RoundResult.SettlementResult.Jackpot?.WinningAmount ?? 0);

        public decimal WinLoss => RoundResult.FreeSpin ? BetWin : BetWin - RoundResult.TotalAmount;

        public string SystemType { get; set; }

        public bool EnabledJackpot { get; set; }

        public static string GetJackpotSymbolFile()
        {
            var jackpotSymbol = new StringBuilder($"{SlotGameConstant.JackpotSymbol}.jackpot");

            if (CultureInfo.CurrentUICulture.Name == "vi-VN")
            {
                jackpotSymbol.Append(".vi-VN");
            }

            return jackpotSymbol.ToString();
        }

        public bool IsJackpotSymbol(byte number) => number == SlotGameConstant.JackpotSymbol && EnabledJackpot;
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