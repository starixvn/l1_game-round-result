using GameRoundResult.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.IntegrationTests.Games.RNGSoccer.BetHistory
{
    public class RNGSoccerBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.RNGSoccer, "RNGSoccer", GameConfigsType.RNG, "123", 32559, Language.EN, "AwayLose"),
                new BetHistoryTestCaseParam((int)GameType.RNGSoccer, "RNGSoccer", GameConfigsType.RNG, "123", 32559, Language.EN, "AwayWin"),
                new BetHistoryTestCaseParam((int)GameType.RNGSoccer, "RNGSoccer", GameConfigsType.RNG, "123", 32559, Language.EN, "HomeLose"),
                new BetHistoryTestCaseParam((int)GameType.RNGSoccer, "RNGSoccer", GameConfigsType.RNG, "123", 32559, Language.EN, "HomeWin"),
                new BetHistoryTestCaseParam((int)GameType.RNGSoccer, "RNGSoccer", GameConfigsType.RNG, "123", 32559, Language.EN, "LosingRound"),
            };
    }
}
