using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
        {
            return new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.BigSmall, "BigSmall", GameConfigsType.RNG, "123", 1, Language.EN, "WinningRound"),
                new BetHistoryTestCaseParam((int)GameType.BigSmall, "BigSmall", GameConfigsType.RNG, "123", 2, Language.EN, "LosingRound"),
            };
        }
    }
}