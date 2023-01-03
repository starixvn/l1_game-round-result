using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.FruitSlot, 1, string.Empty, Language.VN, "Round1"),
            };
        }
    }

    public class FruitSlotRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameType.FruitSlot, "Fruit Slot", Language.EN),
                new RoundResultSelectOptionsTestCaseParam(GameType.FruitSlot, "Xèng Hoa Quả", Language.VN),
            };
        }
    }
}