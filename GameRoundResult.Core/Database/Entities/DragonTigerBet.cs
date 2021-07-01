namespace GameRoundResult.Core.Database.Entities
{
    public class DragonTigerBet : BaseBetEntity
    {
        public decimal Dragon { get; set; }

        public decimal Tie { get; set; }

        public decimal Tiger { get; set; }
    }
}
