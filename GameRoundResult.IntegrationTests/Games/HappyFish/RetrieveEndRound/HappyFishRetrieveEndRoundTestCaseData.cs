using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class HappyFishRetrieveEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam(63,"HappyFish", GameConfigsType.Slot, 291192, 2123, "RR1_RR2_RR3_RR4"),
                new RetrieveEndRoundTestCaseParam(63,"HappyFish", GameConfigsType.Slot, 291193, 1870, "RR5"),
                new RetrieveEndRoundTestCaseParam(63,"HappyFish", GameConfigsType.Slot, 291193, 1895, "RR6"),
                new RetrieveEndRoundTestCaseParam(63,"HappyFish", GameConfigsType.Slot, 291193, 1891, "RR7"),
                new RetrieveEndRoundTestCaseParam(63,"HappyFish", GameConfigsType.Slot, 291192, 2124, "RR8_RR9"),

            };
        }
    }
}