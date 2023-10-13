using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class PontoonBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new()
            {                
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 9000, 97656, Language.EN, "GR1_GR2_GR3"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 9000, 98345, Language.EN, "GR4"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 12, 85360, Language.EN, "GR5"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 12, 85346, Language.EN, "GR6"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 9000, 98577, Language.EN, "GR7_GR8"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 12, 8532246, Language.EN, "GR10_GR13_GR14"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 222241, 79317, Language.EN, "GR11"),
                new BetHistoryTestCaseParam((int)GameType.Pontoon, "Pontoon", GameConfigsType.RNG, 291192, 2039401, Language.EN, "GR12"),
            };
    }
}