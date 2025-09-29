using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests
{
    public class PlinkoBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.Plinko, "Plinko", GameConfigsType.Plinko, "100", 11, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.Plinko, "Plinko", GameConfigsType.Plinko, "100", 10, Language.EN, "WinRound"),
            };
    }
}
