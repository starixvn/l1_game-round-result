using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests.Games.RNGSoccer.RetrieveEndRound
{
    public class RNGSoccerEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.RNGSoccer,"RNGSoccer", GameConfigsType.RNG, "123", 32559, "Losing"),
                new RetrieveEndRoundTestCaseParam((int)GameType.RNGSoccer,"RNGSoccer", GameConfigsType.RNG, "123", 32559, "NotExistRound"),
            };
        }
    }
}
