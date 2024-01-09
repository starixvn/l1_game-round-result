namespace GameRoundResult.Core.Constants
{
    public static class ChineseBlackjack
    {
        public const int MinCardsOnHand = 2;
        public const int MaxCardsOnHand = 5;
        public const int MinNonBustPointValue = 16;
        public const int MaxNonBustPointValue = 21;
    }

    public static class ChineseBlackjackAction
    {
        public const string Stand = "stand";

        public const string Hit = "hit";
    }
}