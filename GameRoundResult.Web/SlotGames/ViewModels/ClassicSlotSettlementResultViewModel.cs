using System.Collections.Generic;

namespace GameRoundResult.Web.SlotGames.ViewModels
{
    public class ClassicSlotSettlementResultViewModel
    {
        public IEnumerable<ClassicSlotWinningLineViewModel> WinningPaylines { get; set; }

        public ClassicSlotSymbolViewModel Bonus { get; set; }

        public ClassicSlotSymbolViewModel FreeSpins { get; set; }

        public ClassicSlotJackpotViewModel Jackpot { get; set; }
    }
}