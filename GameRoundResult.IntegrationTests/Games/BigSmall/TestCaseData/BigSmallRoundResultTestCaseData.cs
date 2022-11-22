using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.BigSmall, 1, "2022-11-01", "en-US", "GetData_Round1"),
                new RoundResultTestCaseParam (GameType.BigSmall, 0, "2022-11-01", "en-US", "GetData_Date1"),
            };
        }
    }
}