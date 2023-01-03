using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(GameType.FruitSlot, 123, 1, Language.EN, "Round1"),
            };
    }
}