using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests
{
    public class PlinkoXBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.PlinkoX, "PlinkoX", GameConfigsType.PlinkoX, "100", 11, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.PlinkoX, "PlinkoX", GameConfigsType.PlinkoX, "100", 10, Language.EN, "WinRound"),
            };
    }
}
