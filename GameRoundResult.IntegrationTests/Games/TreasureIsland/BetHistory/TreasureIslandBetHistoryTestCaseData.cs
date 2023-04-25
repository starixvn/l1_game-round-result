using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class TreasureIslandBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new()
            {
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11052113, Language.EN, "AD1_AD3_AD4_AD5_AD7_AD8_AD9_AD10_AD11_AD12_AD13_AD15_AD16_AD17_AD18_AD19_AD20_AD21_AD23_AD26_AD28"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 1299, Language.EN, "AD2_AD6_AD14_AD24_AD25"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 1298, Language.EN, "AD22"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11, Language.EN, "AD27"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11, Language.VN, "AD27"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291193, 11052113, Language.EN, "AD29"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291193, 11052113, Language.VN, "AD29"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11052113, Language.EN, "AD30"),
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameConfigsType.CascadingSlot, 291192, 11052113, Language.VN, "AD30"),
            };
    }
}