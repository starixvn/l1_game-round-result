using GameRoundResult.Core.Constants;
using System.Collections.Generic;

namespace GameRoundResult.Core.RoundHistory.Models
{
    public static class BaseCurrencyConfig
    {
        public static Dictionary<string, int> MultiplierMapper = new Dictionary<string, int>
        {
            [SystemType.SC1] = 1,
            [SystemType.VG2] = 1000,
            [SystemType.GN] = 1,
        };
        public static Dictionary<string, string> CurrencyMapper = new Dictionary<string, string>
        {
            [SystemType.SC1] = "USD",
            [SystemType.VG2] = "INH",
            [SystemType.GN] = "USD",
        };
    }
}
