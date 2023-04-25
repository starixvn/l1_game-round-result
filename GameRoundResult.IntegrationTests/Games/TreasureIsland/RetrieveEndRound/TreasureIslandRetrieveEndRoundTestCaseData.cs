using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class TreasureIslandRetrieveEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11052113, "AD31_AD32_AD33_AD34"),
                new RetrieveEndRoundTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 1299, "AD35"),
                new RetrieveEndRoundTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 111, "AD36"),
                new RetrieveEndRoundTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 100, "AD37"),
            };
        }
    }
}