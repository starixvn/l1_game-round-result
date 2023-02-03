using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 3, Language.EN, "TD_4_RoundTieBetMultiplesOptions"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 3, Language.VN, "TD_4_RoundTieBetMultiplesOptions"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_5_BetDragon"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_5_BetDragon"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_6_BetPhoenix"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_6_BetPhoenix"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_7_BetPair8Plus"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_7_BetPair8Plus"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_8_BetThreeOfAKind"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_8_BetThreeOfAKind"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_9_BetStraightFlush"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_9_BetStraightFlush"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_10_BetFlush"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_10_BetFlush"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.EN, "TD_11_BetStraight"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 1, Language.VN, "TD_11_BetStraight"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 6, Language.EN, "TD_13_NotExistRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 6, Language.VN, "TD_13_NotExistRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 5, Language.EN, "TD_14_RunningRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 5, Language.VN, "TD_14_RunningRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 2, Language.EN, "TD_16_NotExistBet"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 2, Language.VN, "TD_16_NotExistBet"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 3, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 3, Language.VN, "LosingRound"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 4, Language.EN, "FrationalOdds"),
                new BetHistoryTestCaseParam(GameType.WinThreeCards, 123, 4, Language.VN, "FrationalOdds"),
            };
    }
}