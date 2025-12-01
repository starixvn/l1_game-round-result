using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class LudoEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.Ludo,"Ludo", GameConfigsType.RNG, "100", 23202, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.Ludo,"Ludo", GameConfigsType.RNG, "100", 23202, "NotExistRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.Ludo,"Ludo", GameConfigsType.RNG, "100", 23853, "Losing"),
            };
        }
    }
}