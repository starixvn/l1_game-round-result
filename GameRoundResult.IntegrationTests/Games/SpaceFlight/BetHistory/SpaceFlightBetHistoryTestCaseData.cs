using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class SpaceFlightBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new()
            {
                new BetHistoryTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, "291192", 49619, Language.EN, "GR4_NotCashOut"),
                new BetHistoryTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, "291192", 50185, Language.EN, "GR5_OnlyHalfCashOut"),
                new BetHistoryTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, "291192", 50196, Language.EN, "GR6_HalfCashOutAndCashOut"),
            };
    }
}