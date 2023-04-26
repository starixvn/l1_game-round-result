using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.CascadingSlotGames.ViewModels
{
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
}