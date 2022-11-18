using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallEndRoundTestCaseData : TestCaseDataProvider<EndRoundTestCaseParam>
    {
        public override List<EndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<EndRoundTestCaseParam>
            {
                new EndRoundTestCaseParam(GameType.BigSmall, 123, 1, 10, 0, 10, new DateTimeOffset(2022, 11, 1, 08, 0, 0, new TimeSpan()), "0", null),
            };
        }
    }
}