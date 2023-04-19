namespace GameRoundResult.Web.CascadingSlotGames.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameRoundResult.Web.Configuration;
    using GameRoundResult.Web.Models;

    public class BaseCascadingSlotTicketViewModel : GameTicketViewModel
    {
        public string GameName { get; set; }

        public BaseCascadingSlotRoundViewModel Round { get; set; }

        public IEnumerable<BaseCascadingSlotRoundMultiplierViewModel> Multipliers { get; set; }
    }

    public class BaseCascadingSlotRoundViewModel : RoundResultViewModel
    {
        public byte BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal BetWin { get; set; }

        public int TotalMultiplier { get; set; }

        public int Multiplier { get; set; }

        public decimal TotalTumbleWin { get; set; }

        public bool FreeSpin { get; set; }

        public string Result { get; set; }

        public BaseCascadingSlotSettlementResultViewModel SettlementResult { get; set; }

        public decimal WinLoss => FreeSpin ? BetWin : BetWin - TotalAmount;

        public string DisplayWinLoss => WinLoss.Format();

        public string DisplayTotalAmount => (FreeSpin ? 0 : TotalAmount).Format();

        public IEnumerable<byte> Board => Result.Split(',').Select(value => byte.Parse(value));

        public bool ReachMaxWin { get; set; }

        public bool IsWinning => WinLoss > 0;
    }

    public class BaseCascadingSlotRoundMultiplierViewModel : TimeViewModel
    {
        public long RoundId { get; set; }

        public int Multiplier { get; set; }

        public int TotalMultiplier { get; set; }
    }

    public class BaseCascadingSlotSettlementResultViewModel
    {
        public IEnumerable<BaseCascadingSlotTumbleViewModel> Tumbles { get; set; }

        public BaseCascadingSlotFreeSpinViewModel FreeSpins { get; set; }

        public string DisplayTumbleWin => Tumbles.Sum(x => x.Win).Format();
    }

    public class BaseCascadingSlotTumbleViewModel
    {
        public Dictionary<byte, BaseCascadingSlotWinningSymbolViewModel> Icons { get; set; }

        public decimal Win { get; set; }

        public string OriginalBoard { get; set; }

        public IEnumerable<int> Multipliers { get; set; }

        public IEnumerable<byte> Board => OriginalBoard.Split(',').Select(value => byte.Parse(value));
    }

    public class BaseCascadingSlotWinningSymbolViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }

        public decimal Win { get; set; }
    }

    public class BaseCascadingSlotFreeSpinViewModel
    {
        public byte Count { get; set; }

        public byte Odds { get; set; }
    }
}