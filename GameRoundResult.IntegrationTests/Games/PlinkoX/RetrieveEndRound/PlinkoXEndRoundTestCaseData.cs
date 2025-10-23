using GameRoundResult.Core.Constants;
using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class PlinkoXEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.PlinkoX, "PlinkoX", GameConfigsType.PlinkoX, "100", 11, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.PlinkoX, "PlinkoX", GameConfigsType.PlinkoX, "123", 1, "NotExistRound"),
            };
        }
    }
}
