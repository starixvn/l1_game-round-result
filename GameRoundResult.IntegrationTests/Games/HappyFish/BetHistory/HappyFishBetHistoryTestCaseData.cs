using System.Collections.Generic;

namespace GameRoundResult.IntegrationTests
{
    public class HappyFishBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new()
            {
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1895, Language.EN, "RR12_RR14"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291192, 1, Language.EN, "RR10_RR11_RR13_RR15_RR19_RR20_RR23"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1870, Language.EN, "RR16"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1891, Language.EN, "RR22"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1891, Language.VN, "RR22"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1, Language.EN, "RR24"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1, Language.VN, "RR24"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1000, Language.EN, "RR25"),
                new BetHistoryTestCaseParam(63, "HappyFish", 291193, 1000, Language.VN, "RR25"),
            };
    }
}