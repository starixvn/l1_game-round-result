using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using System.Collections.Generic;

namespace GameRoundResult.Web.PlinkoGames.ViewModels
{
    public class PlinkoGameTicketViewModel : GameTicketViewModel
    {
        public PlinkoGameRoundResultViewModel RoundResult { get; set; }
    }
}
