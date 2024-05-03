using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall2.RoundResult
{
    public class SeBall1RoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.SeBall1, 1, string.Empty, Language.EN, "GR3_4_Blue3"),
                new RoundResultTestCaseParam (GameType.SeBall1, 1, "2024-12-01", Language.EN, "GR3_4_Blue4"),
                new RoundResultTestCaseParam (GameType.SeBall1, 1, string.Empty, Language.EN, "GR3_4_Red3"),
                new RoundResultTestCaseParam (GameType.SeBall1, 1, string.Empty, Language.EN, "GR3_4_Red2"),
                new RoundResultTestCaseParam (GameType.SeBall1, 1, string.Empty, Language.EN, "GR3_4_Red4"),
                new RoundResultTestCaseParam (GameType.SeBall1, 10, string.Empty, Language.EN, "GR7_8_9_NotExistRound"),
            };
        }
    }
}