using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall2.RoundResult
{
    public class LuckyThreeRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.LuckyThree, 1, string.Empty, Language.EN, "Red3"),
                new RoundResultTestCaseParam (GameType.LuckyThree, 2, string.Empty, Language.EN, "Red2"),
                new RoundResultTestCaseParam (GameType.LuckyThree, 3, string.Empty, Language.EN, "Blue2"),
                new RoundResultTestCaseParam (GameType.LuckyThree, 5, string.Empty, Language.EN, "Blue3"),
                new RoundResultTestCaseParam (GameType.LuckyThree, 10, string.Empty, Language.EN, "NotExistRound"),
            };
        }
    }
}