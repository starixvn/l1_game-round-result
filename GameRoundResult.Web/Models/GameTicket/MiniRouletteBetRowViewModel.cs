using GameRoundResult.Core.Database.Entities;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class MiniRouletteBetRowViewModel : GameTicketViewModel
    {
        public MiniRouletteSettlementResultViewModel SettlementResult { get; set; }

        public MiniRouletteBetLogViewModel Bet { get; set; }

        public List<BetDetail> SettlementDetails { get; set; }
    }
}
