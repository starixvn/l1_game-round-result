using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class SpaceFlightEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, 291192, 7299, "GR25_NotCashOut"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, 291192, 20390, "GR26_HalfCashOut"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, 291192, 20441, "GR27_CashOut"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SpaceFlight, "SpaceFlight", GameConfigsType.Crash, 291192, 20460, "GR28_HalfCashOut_CashOut"),
            };
        }
    }
}