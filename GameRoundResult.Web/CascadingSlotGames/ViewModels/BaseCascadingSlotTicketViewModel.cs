namespace GameRoundResult.Web.CascadingSlotGames.ViewModels
{
    using System.Collections.Generic;
    using GameRoundResult.Web.Models;

    public class BaseCascadingSlotTicketViewModel : GameTicketViewModel
    {
        public string GameName { get; set; }

        public BaseCascadingSlotRoundViewModel Round { get; set; }

        public IEnumerable<BaseCascadingSlotRoundMultiplierViewModel> Multipliers { get; set; }
    }
}