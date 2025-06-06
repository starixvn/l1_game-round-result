using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests
{
    public class MiniRouletteBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.MiniRoulette, "MiniRoulette", GameConfigsType.RNG, "68915", 2346492, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.MiniRoulette, "MiniRoulette", GameConfigsType.RNG, "68915", 2346516, Language.EN, "OddWin"),
                new BetHistoryTestCaseParam((int)GameType.MiniRoulette, "MiniRoulette", GameConfigsType.RNG, "68915", 2346587, Language.EN, "RedWin"),

            };
    }
}
