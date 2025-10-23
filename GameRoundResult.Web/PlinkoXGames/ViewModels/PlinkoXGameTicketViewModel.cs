using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using System.Collections.Generic;

namespace GameRoundResult.Web.PlinkoXGames.ViewModels
{
    public class PlinkoXGameTicketViewModel : GameTicketViewModel
    {
        public PlinkoXGameRoundResultViewModel RoundResult { get; set; }
    }
}
