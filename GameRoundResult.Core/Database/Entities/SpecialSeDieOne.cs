namespace GameRoundResult.Core.Database.Entities
{
    public class SpecialSeDieOne : BaseBetEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }

        public decimal Refund { get; set; }
    }
}