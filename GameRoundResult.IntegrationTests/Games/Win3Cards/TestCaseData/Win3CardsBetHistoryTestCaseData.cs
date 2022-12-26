using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 1, Language.EN, "Round1"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 1, Language.VN, "Round1"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 2, Language.EN, "NotExistBet"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 2, Language.VN, "NotExistBet"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 3, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 3, Language.VN, "LosingRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.EN, "BetAllOptions"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.VN, "BetAllOptions"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.EN, "FrationalOdds"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 4, Language.VN, "FrationalOdds"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 5, Language.EN, "RunningRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 5, Language.VN, "RunningRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 6, Language.EN, "NotExistRound"),
                new BetHistoryTestCaseParam(GameType.Win3Cards, 123, 6, Language.VN, "NotExistRound"),
            };
    }
}