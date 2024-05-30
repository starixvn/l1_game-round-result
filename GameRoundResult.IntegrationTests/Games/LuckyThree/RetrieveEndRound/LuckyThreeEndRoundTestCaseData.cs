using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall2.RetrieveEndRound
{
    public class LuckyThreeEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.LuckyThree, "LuckyThree", GameConfigsType.RNG, "123", 2, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.LuckyThree, "LuckyThree", GameConfigsType.RNG, "123", 3, "NotExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.LuckyThree, "LuckyThree", GameConfigsType.RNG, "123", 10, "NotExistRound"),
            };
        }
    }
}