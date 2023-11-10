using System.Collections.Generic;

namespace GameRoundResult.Core.Constants
{
    public static class CrashGameAction
    {
        public const string Refund = "refund";
        public const string CashOut = "cashOut";
        public const string HalfCashOut = "halfCashOut";
    }

    public static class CrashGameTolgeeAction
    {
        public static Dictionary<string, string> Actions = new()
        {
            {CrashGameAction.CashOut, "cashout" },
            {CrashGameAction.HalfCashOut, "cashout_50%" },
            {CrashGameAction.Refund, "refund" },
        };
    }
}