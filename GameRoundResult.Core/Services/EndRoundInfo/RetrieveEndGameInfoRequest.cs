namespace GameRoundResult.Core.Services
{
    public class RetrieveEndGameInfoRequest
    {
        public long GameRoundId { get; set; }

        public int GameTypeId { get; set; }

        public string PlayerId { get; set; }

        public bool FreeBet { get; set; }

        public string OperatorId { get; set; }

        public string GameName { get; set; }

        public string SiteId { get; set; }
    }
}