using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class SeDie3BetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
        {
            return new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.SeDie3, "SeDie3", GameConfigsType.RNG, "588", 12515, Language.EN, "WinningRound"),
                new BetHistoryTestCaseParam((int)GameType.SeDie3, "SeDie3", GameConfigsType.RNG, "6001", 4220, Language.EN, "LosingRound"),
            };
        }
    }
}