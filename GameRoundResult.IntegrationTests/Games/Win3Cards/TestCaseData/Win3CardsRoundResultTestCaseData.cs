using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, "2022-12-01", Language.EN, "GetData_Round1"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, "2022-12-01", Language.VN, "GetData_Round1.vi-VN"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-01", Language.EN, "GetData_ByDate"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-01", Language.VN, "GetData_ByDate.vi-VN"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-10", Language.EN, "GetData_NotExistRound"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 10, "2022-12-01", Language.VN, "GetData_NotExistRound"),
            };
        }
    }

    public class Win3CardsRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameType.Win3Cards, "Win 3 Cards", Language.EN),
                new RoundResultSelectOptionsTestCaseParam(GameType.Win3Cards, "Trác Kim Hoa", Language.VN),
            };
        }
    }
}