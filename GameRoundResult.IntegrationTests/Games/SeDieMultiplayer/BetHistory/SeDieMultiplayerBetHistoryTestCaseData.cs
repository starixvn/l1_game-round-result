using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class SeDieMultiplayerBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
        {
            return new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.SeDieMultiplayer, "SeDieMultiplayer", 0, "1111111", 7654322, Language.EN, "WinningRound"),
                new BetHistoryTestCaseParam((int)GameType.SeDieMultiplayer, "SeDieMultiplayer", 0, "1111111", 1234568, Language.EN, "LosingRound"),
            };
        }
    }
}
