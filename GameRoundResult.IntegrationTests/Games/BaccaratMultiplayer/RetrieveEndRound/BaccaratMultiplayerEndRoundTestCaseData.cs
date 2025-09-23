using GameRoundResult.Core.Constants;
using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class BaccaratMultiplayerEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.BaccaratMultiplayer, "BaccaratMultiplayer", GameConfigsType.RNG, "100", 19880, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.BaccaratMultiplayer, "BaccaratMultiplayer",GameConfigsType.RNG, "123", 1, "NotExistRound"),
            };
        }
    }
}
