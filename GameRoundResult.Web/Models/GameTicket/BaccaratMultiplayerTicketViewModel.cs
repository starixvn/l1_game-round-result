using System;

namespace GameRoundResult.Web.Models
{
    public class BaccaratMultiplayerTicketViewModel : GameTicketViewModel
    {
        public BaccaratMultiplayerRoundResultViewModel RoundResult { get; set; }

        public BaccaratMultiplayerBetViewModel Bet { get; set; }
    }

    public class BaccaratMultiplayerBetViewModel
    {
        public DateTime Time { get; set; }

        public decimal Banker { get; set; }

        public decimal Player { get; set; }

        public decimal AnyPair { get; set; }

        public decimal Tie { get; set; }

        public decimal BetWin { get; set; }
    }
}
