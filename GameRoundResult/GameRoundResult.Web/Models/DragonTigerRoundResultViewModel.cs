namespace GameRoundResult.Web.Models
{
    public class DragonTigerRoundResultViewModel : RoundResultViewModel
    {
        public CardViewModel Dragon { get; set; }

        public CardViewModel Tiger { get; set; }
    }

    public class CardViewModel
    {
        public byte Number { get; set; }

        public byte Type { get; set; }
    }
}