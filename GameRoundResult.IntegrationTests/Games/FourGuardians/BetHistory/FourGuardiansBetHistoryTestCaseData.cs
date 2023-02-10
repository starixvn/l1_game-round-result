using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class FourGuardiansBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(29, "FourGuardians", 291192, 42131, Language.EN, "NormalSpins"),
            };
    }
}