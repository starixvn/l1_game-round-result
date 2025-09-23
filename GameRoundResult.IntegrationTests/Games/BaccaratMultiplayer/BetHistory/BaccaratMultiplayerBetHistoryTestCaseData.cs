using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BaccaratMultiplayerBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
        {
            return new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.BaccaratMultiplayer, "BaccaratMultiplayer", GameConfigsType.RNG, "100", 19880, Language.EN, "WinningRound"),
                new BetHistoryTestCaseParam((int)GameType.BaccaratMultiplayer, "BaccaratMultiplayer", GameConfigsType.RNG, "100", 19879, Language.EN, "LosingRound"),
            };
        }
    }
}
