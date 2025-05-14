using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class RNGSoccerRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.RNGSoccer, 32559, string.Empty, Language.EN, "AwayWin"),
                new RoundResultTestCaseParam (GameType.RNGSoccer, 32559, string.Empty, Language.EN, "HomeWin"),
                new RoundResultTestCaseParam (GameType.RNGSoccer, 32559, string.Empty, Language.EN, "DrawWin"),
                new RoundResultTestCaseParam (GameType.RNGSoccer, 0, string.Empty, Language.EN, "NotExistRound"),
            };
        }
    }

    public class RNGSoccerRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameType.RNGSoccer, "RNG Soccer", Language.EN),
            };
        }
    }
}