using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class TreasureIslandBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new()
            {
                new BetHistoryTestCaseParam(47, "TreasureIsland", GameType.CascadingSlot, 291192, 11052113, Language.EN, "TD1"),
            };
    }
}