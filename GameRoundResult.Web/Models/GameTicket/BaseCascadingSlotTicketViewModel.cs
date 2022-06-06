namespace GameRoundResult.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BaseCascadingSlotTicketViewModel : GameTicketViewModel
    {
        public BaseCascadingSlotRoundViewModel Round { get; set; }

        public IEnumerable<BaseCascadingSlotRoundMultiplierViewModel> Multipliers { get; set; }
    }

    public class BaseCascadingSlotRoundViewModel : RoundResultViewModel
    {
        public byte BetLevel { get; set; }

        public decimal CoinValue { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal BetWin { get; set; }

        public byte TotalMultiplier { get; set; }

        public byte Multiplier { get; set; }

        public decimal TotalTumbleWin { get; set; }

        public bool FreeSpin { get; set; }

        public string Result { get; set; }

        public BaseCascadingSlotSettlementResultViewModel SettlementResult { get; set; }

        public decimal WinLoss => FreeSpin ? BetWin : BetWin - TotalAmount;

        public IEnumerable<byte> Board => Result.Split(',').Select(value => byte.Parse(value));
    }

    public class BaseCascadingSlotRoundMultiplierViewModel
    {
        public DateTime Time { get; set; }

        public long RoundId { get; set; }

        public byte Multiplier { get; set; }

        public byte TotalMultiplier { get; set; }
    }

    public class BaseCascadingSlotSettlementResultViewModel
    {
        public IEnumerable<BaseCascadingSlotTumbleViewModel> Tumbles { get; set; }

        public BaseCascadingSlotFreeSpinViewModel FreeSpins { get; set; }

    }

    public class BaseCascadingSlotTumbleViewModel
    {
        public Dictionary<byte, BaseCascadingSlotWinningSymbolViewModel> Icons { get; set; }

        public decimal Win { get; set; }

        public string OriginalBoard { get; set; }

        public IEnumerable<byte> Multipliers { get; set; }

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
