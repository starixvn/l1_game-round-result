using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall1.RoundResult
{
    public class BacBall1RoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.BacBall1, 0, "2024-12-01", Language.EN, "NotExistRound"),
                new RoundResultTestCaseParam (GameType.BacBall1, 1, "2024-12-01", Language.EN, "GR3_GR4_01_PlayerWin"),
                new RoundResultTestCaseParam (GameType.BacBall1, 1, string.Empty, Language.EN, "GR3_GR4_02_BankerWin"),
                new RoundResultTestCaseParam (GameType.BacBall1, 1, string.Empty, Language.EN, "GR3_GR4_03_TieWin"),
            };
        }
    }
}