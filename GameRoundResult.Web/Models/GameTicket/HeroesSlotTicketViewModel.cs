using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class HeroesSlotTicketViewModel : GameTicketViewModel
    {
        public HeroesSlotRoundResultViewModel RoundResult { get; set; }

        public decimal BetWin => RoundResult.BetWin + (RoundResult.SettlementResult.Jackpot?.WinningAmount ?? 0);

        public decimal WinLoss => RoundResult.FreeSpin ? BetWin : BetWin - RoundResult.TotalAmount;
    }

    public class HeroesSlotRoundResultViewModel
    {
        public long Round { get; set; }

        public DateTime Time { get; set; }

        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public IEnumerable<HeroesSlotBonusChestViewModel> BonusChests { get; set; }

        public HeroesSlotSettlementResultViewModel SettlementResult { get; set; }

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
    }

    public class HeroesSlotBonusChestViewModel
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class HeroesSlotSettlementResultViewModel
    {
        public IEnumerable<HeroesSlotWinningLineViewModel> WinningPaylines { get; set; }

        public HeroesSlotBonusViewModel Bonus { get; set; }

        public HeroesSlotFreeSpinViewModel FreeSpins { get; set; }

        public HeroesSlotJackpotViewModel Jackpot { get; set; }
    }

    public class HeroesSlotJackpotViewModel
    {
        public byte WinningLine { get; set; }

        public decimal WinningAmount { get; set; }
    }

    public class HeroesSlotWinningLineViewModel
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class HeroesSlotBonusViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class HeroesSlotFreeSpinViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}