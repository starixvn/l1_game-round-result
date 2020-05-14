namespace GameRoundResult.Core.Database.Entities
{
    public class BigSmallRound : GameRound
    {
        public byte Dice1 { get; set; }

        public byte Dice2 { get; set; }

        public byte Dice3 { get; set; }
    }
}