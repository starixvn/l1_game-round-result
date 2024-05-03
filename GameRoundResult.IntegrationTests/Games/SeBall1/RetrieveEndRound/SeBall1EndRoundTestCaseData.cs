using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall2.RetrieveEndRound
{
    public class SeBall1EndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.SeBall1, "SeBall1", GameConfigsType.RNG, "123", 1, "GR31_32_33_34_36_ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SeBall1, "SeBall1", GameConfigsType.RNG, "123", 10, "GR35_37_38_NotExistRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SeBall1, "SeBall1", GameConfigsType.RNG, "123", 1, "Losing"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SeBall1, "SeBall1", GameConfigsType.RNG, "123", 2, "NotExistBet"),
            };
        }
    }
}