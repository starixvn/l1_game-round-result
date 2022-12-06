using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
        {
            return new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(GameType.BigSmall, 123, 1, Language.EN, "Index_Round1"),
                new BetHistoryTestCaseParam(GameType.BigSmall, 123, 2, Language.EN, "Index_Round2"),
            };
        }
    }
}