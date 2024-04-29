using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Requests.RoundHistory
{
    public class RoundHistoryBetLogRequest
    {
        public GameType Game { get; set; }
        public long RoundId { get; set; }
        public string PartnerId { get; set; }
        public string UserId { get; set; }
        public bool ConvertToUSD { get; set; }
    }
}
