using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class ColorGameBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "FractionalOddsLose"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "FractionalOddsWin"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR1_HotWins"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR2_HotWins"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR3_HotLose"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR4_ColdWins"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR5_ColdWins"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR6_ColdLose"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR7_YellowWins"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR8_YellowWinsDouble"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR9_YellowWinsTriple"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR11_ColdBlueWhiteWin"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR12_ColdLoseYellowWinWhiteWin"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR13_HotWinYellowWinWhiteWin"),
                new BetHistoryTestCaseParam((int)GameType.ColorGame, "ColorGame", GameConfigsType.RNG, 8043883, 35599, Language.EN, "RR14_HotLoseYellowWinWhiteWin"),                
            };
    }
}