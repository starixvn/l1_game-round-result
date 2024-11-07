using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.SevenUpDown.RetrieveEndRound
{
    public class SevenUpDownEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.SevenUpDown,"SevenUpDown", GameConfigsType.RNG, "1003", 22613, "RER_1_2_3_ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SevenUpDown,"SevenUpDown", GameConfigsType.RNG, "123", 2, "NotExistRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SevenUpDown,"SevenUpDown", GameConfigsType.RNG, "722446", 2166, "Losing"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SevenUpDown,"SevenUpDown", GameConfigsType.RNG, "1003", 33864, "RER_5_RunningRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.SevenUpDown,"SevenUpDown", GameConfigsType.RNG, "1407", 1, "RER_6_NotExistBet"),
            };
        }
    }
}
