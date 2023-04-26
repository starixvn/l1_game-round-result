using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.CascadingSlotGames.ViewModels
{
    public class BaseCascadingSlotRoundMultiplierViewModel : TimeViewModel
    {
        public long RoundId { get; set; }

        public int Multiplier { get; set; }

        public int TotalMultiplier { get; set; }
    }
}