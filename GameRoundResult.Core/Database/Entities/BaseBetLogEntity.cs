namespace GameRoundResult.Core.Database.Entities
{
    public class BaseBetLogEntity : Document
    {
        public string Uid { get; set; }

        public string Name { get; set; }

        public long RoundId { get; set; }

        public int? PlayerId { get; set; }

        public string SiteId { get; set; }

        public string Currency { get; set; }

        public string OperatorId { get; set; }

        public decimal Rate { get; set; }
    }
}