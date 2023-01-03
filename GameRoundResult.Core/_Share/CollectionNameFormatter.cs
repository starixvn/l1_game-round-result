namespace GameRoundResult.Core._Share
{
    public static class CollectionNameFormatter
    {
        public static readonly string RoundSuffix = "rounds";
        public static readonly string BetSuffix = "bets";
        public static readonly string BetLogSuffix = "betlogs";

        private static string Format(string name, string suffix) => $"{name}_{suffix}";

        public static string Round(string name) => Format(name, RoundSuffix);

        public static string Bet(string name) => Format(name, BetSuffix);

        public static string BetLog(string name) => Format(name, BetLogSuffix);
    }
}