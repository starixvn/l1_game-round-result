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
                new RoundResultTestCaseParam (GameType.BigSmall, 1, "2022-11-01", Language.EN, "GetData_Round1"),
                new RoundResultTestCaseParam (GameType.BigSmall, 0, "2022-11-01", Language.EN, "GetData_Date1"),
            };
        }
    }

    public class BigSmallRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameType.BigSmall, "Big Small", Language.EN),
                new RoundResultSelectOptionsTestCaseParam(GameType.BigSmall, "Tài Xỉu", Language.VN),
            };
        }
    }
}