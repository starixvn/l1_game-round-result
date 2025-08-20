using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CascadingSlotGames.ViewModels
{
    public class BaseCascadingSlotRoundViewModel : RoundResultViewModel
    {
        public byte BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public string DisplayCoinValue => CoinValue.Format();

        public decimal TotalAmount { get; set; }

        public string DisplayTotalAmount => TotalAmount.Format();
        public decimal BetWin { get; set; }

        public string DisplayBetWin => BetWin.Format();

        public int TotalMultiplier { get; set; }

        public int Multiplier { get; set; }

        public decimal TotalTumbleWin { get; set; }

        public bool FreeSpin { get; set; }
        public bool BuyFreeSpin { get; set; }

        public string Result { get; set; }

        public BaseCascadingSlotSettlementResultViewModel SettlementResult { get; set; }

        public decimal WinLoss => FreeSpin ? BetWin : BetWin - TotalAmount;

        public string DisplayWinLoss => WinLoss.Format();

        public string DisplayTotalBetAmount => (FreeSpin ? 0 : TotalAmount).Format();

        public IEnumerable<byte> Board => Result.Split(',').Select(value => byte.Parse(value));

        public bool ReachMaxWin { get; set; }

        public bool IsWinning => WinLoss > 0;
    }

    public class BaseCascadingSlotSettlementResultViewModel
    {
        public IEnumerable<BaseCascadingSlotTumbleViewModel> Tumbles { get; set; }

        public BaseCascadingSlotFreeSpinViewModel FreeSpins { get; set; }

        public string DisplayTumbleWin => Tumbles.Sum(x => x.Win).Format();
    }

    public class BaseCascadingSlotFreeSpinViewModel
    {
        public byte Count { get; set; }

        public byte Odds { get; set; }

        public decimal? Win { get; set; }
    }
}