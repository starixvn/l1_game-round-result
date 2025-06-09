namespace GameRoundResult.Web.Models
{
    public class MiniRouletteBetRowViewModel : GameTicketViewModel
    {
        public MiniRouletteSettlementResultViewModel SettlementResult { get; set; }

        public MiniRouletteBetLogViewModel Bet { get; set; }
    }
}
