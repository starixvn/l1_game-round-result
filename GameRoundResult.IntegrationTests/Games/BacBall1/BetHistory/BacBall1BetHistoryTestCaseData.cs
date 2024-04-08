using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BacBall1BetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR12_To_GR15_PlayerWin"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR16_BetChoiceMultiple_BankerWin"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR17_BetChoicePlayer_PlayerLose"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR18_BetChoiceBanker_BankerLose"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR19_BetChoiceTie_TieLose"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR20_To_GR22_MultipleFractionalOdds"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR23_PlayerFractionalOdds"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR24_AmountFormat"),
                new BetHistoryTestCaseParam((int)GameType.BacBall1, "BacBall1", GameConfigsType.RNG, "123", 48586, Language.EN, "GR27_GR30_BetChoiceTie_TieWin"),
            };
    }
}