namespace GameRoundResult.Web.Models
{
    public class BigSmallRoundResultViewModel : RoundResultViewModel
    {
        public byte Dice1 { get; set; }

        public byte Dice2 { get; set; }

        public byte Dice3 { get; set; }

        public int Total => Dice1 + Dice2 + Dice3;
    }
}