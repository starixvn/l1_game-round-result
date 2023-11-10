namespace GameRoundResult.Core.Services
{
    public class RetrieveEndGameInfoRequest
    {
        public int GameRoundId { get; set; }

        public byte GameTypeId { get; set; }

        public int PlayerId { get; set; }

        public bool FreeBet { get; set; }

        public string OperatorId { get; set; }

        public string GameName { get;set; }
    }
}