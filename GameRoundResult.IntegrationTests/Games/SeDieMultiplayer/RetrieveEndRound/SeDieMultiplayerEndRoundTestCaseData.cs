using GameRoundResult.Core.Constants;
using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class SeDieMultiplayerEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.SeDieMultiplayer, "SeDieMultiplayer", 0, "1111111", 1234567, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SeDieMultiplayer, "SeDieMultiplayer", 0, "123", 1, "NotExistRound"),
            };
        }
    }
}
