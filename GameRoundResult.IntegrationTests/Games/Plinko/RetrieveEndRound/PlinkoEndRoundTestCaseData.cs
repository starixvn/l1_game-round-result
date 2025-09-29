using GameRoundResult.Core.Constants;
using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class PlinkoEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.Plinko, "Plinko", GameConfigsType.Plinko, "100", 11, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.Plinko, "Plinko", GameConfigsType.Plinko, "123", 1, "NotExistRound"),
            };
        }
    }
}
