namespace GameRoundResult.Core.Constants
{
    public static class Pontoon
    {
        public const int MaxCardsOnHand = 5;
        public const int PontoonValue = 21;
        public const int PontoonCardCount = 2;
    }

    public static class PontoonAction
    {
        public const string Split = "split";

        public const string Stand = "stand";

        public const string Hit = "hit";

        public const string Double = "double";
    }
}