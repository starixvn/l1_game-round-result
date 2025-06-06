using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests
{
    public class MiniRouletteEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.MiniRoulette, "MiniRoulette", GameConfigsType.RNG, "68915", 2346587, "ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.MiniRoulette, "MiniRoulette", GameConfigsType.RNG, "68915", 1, "NotExistRound"),
            };
        }
    }
}
