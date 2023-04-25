using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.FruitSlot, "FruitSlot", GameConfigsType.SlotRNG, 123, 1, Language.EN, "Round1"),
            };
    }
}