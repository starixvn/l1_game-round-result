namespace GameRoundResult.Core.Database.Entities
{
    public class ThreeCardsBet : BaseBetEntity
    {
        public decimal Red { get; set; }
        public decimal Black { get; set; }
        public decimal Diamonds { get; set; }
        public decimal Hearts { get; set; }
        public decimal Spades { get; set; }
        public decimal Clubs { get; set; }

        public ThreeCardsOdds Odds { get; set; }
    }

    public class ThreeCardsOdds
    {
        public decimal Red { get; set; }
        public decimal Black { get; set; }
        public decimal Diamonds { get; set; }
        public decimal Hearts { get; set; }
        public decimal Spades { get; set; }
        public decimal Clubs { get; set; }
    }
}