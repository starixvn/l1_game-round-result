using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 1, Language.EN, "Index_Round1"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 1, Language.VN, "Index_Round1.vi-VN"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 2, Language.EN, "Index_Round2_NotExistBet"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 2, Language.VN, "Index_Round2_NotExistBet.vi-VN"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 3, Language.EN, "Index_Round3_Lose"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 3, Language.VN, "Index_Round3_Lose.vi-VN"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.EN, "Index_Round4_BetAllOptions"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.VN, "Index_Round4_BetAllOptions.vi-VN"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 5, Language.EN, "Index_NotExistRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 5, Language.VN, "Index_NotExistRound.vi-VN"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 6, Language.EN, "Index_NotExistRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 6, Language.VN, "Index_NotExistRound.vi-VN"),
            };
    }
}