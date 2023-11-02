using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BandarQiuQiuBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {
                new BetHistoryTestCaseParam((int)GameType.BandarQiuQiu, "BandarQiuQiu", GameConfigsType.RNG, 5346002, 15469, Language.EN, "RR0_Lose"),
                new BetHistoryTestCaseParam((int)GameType.BandarQiuQiu, "BandarQiuQiu", GameConfigsType.RNG, 5346002, 13598, Language.EN, "RR1_DiamondWins"),
                new BetHistoryTestCaseParam((int)GameType.BandarQiuQiu, "BandarQiuQiu", GameConfigsType.RNG, 5346002, 15506, Language.EN, "RR2_HeartWins"),
                new BetHistoryTestCaseParam((int)GameType.BandarQiuQiu, "BandarQiuQiu", GameConfigsType.RNG, 5346002, 15535, Language.EN, "RR3_SpadeWins"),
                new BetHistoryTestCaseParam((int)GameType.BandarQiuQiu, "BandarQiuQiu", GameConfigsType.RNG, 5346002, 15563, Language.EN, "RR4_ClubWins"),
            };
    }
}