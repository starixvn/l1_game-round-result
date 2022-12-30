namespace GameRoundResult.Core._Share
{
    public static class CollectionNameFormatter
    {
        public static readonly string RoundSuffix = "rounds";
        public static readonly string BetSuffix = "bets";
        public static readonly string BetLogSuffix = "betlogs";

        public static string Format(string name, string suffix) => $"{name}_{suffix}";

        public static string RoundName(string name) => Format(name, RoundSuffix);

        public static string BetName(string name) => Format(name, BetSuffix);

        public static string BetLogName(string name) => Format(name, BetLogSuffix);
    }
}