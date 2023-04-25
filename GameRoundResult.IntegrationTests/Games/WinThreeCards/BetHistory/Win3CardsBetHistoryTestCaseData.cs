using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 3, Language.EN, "TD_4_RoundTieBetMultiplesOptions"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 3, Language.VN, "TD_4_RoundTieBetMultiplesOptions"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_5_BetDragon"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_5_BetDragon"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_6_BetPhoenix"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_6_BetPhoenix"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_7_BetPair8Plus"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_7_BetPair8Plus"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_8_BetThreeOfAKind"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_8_BetThreeOfAKind"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_9_BetStraightFlush"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_9_BetStraightFlush"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_10_BetFlush"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_10_BetFlush"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.EN, "TD_11_BetStraight"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 1, Language.VN, "TD_11_BetStraight"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 6, Language.EN, "TD_13_NotExistRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 6, Language.VN, "TD_13_NotExistRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 5, Language.EN, "TD_14_RunningRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 5, Language.VN, "TD_14_RunningRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 2, Language.EN, "TD_16_NotExistBet"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 2, Language.VN, "TD_16_NotExistBet"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 3, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 3, Language.VN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 4, Language.EN, "FrationalOdds"),
                new BetHistoryTestCaseParam((int)GameType.WinThreeCards, "WinThreeCards", GameConfigsType.RNG, 123, 4, Language.VN, "FrationalOdds"),
            };
    }
}