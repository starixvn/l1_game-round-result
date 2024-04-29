namespace GameRoundResult.Web.Models.RoundHistory
{
    public class RoundHistoryBetLogViewModel
    {
        public GameTicketViewModel TicketModel { get; set; }
        public int BaseCurrencyMultiplier { get; set; }
        public string BaseCurrency { get; set; }
        public bool ConvertToUSD { get; set; }
    }
}
