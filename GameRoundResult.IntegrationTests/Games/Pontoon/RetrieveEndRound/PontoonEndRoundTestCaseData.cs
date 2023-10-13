using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class PontoonEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam(72, "Pontoon", GameConfigsType.RNG, 600, 44352, "GR16_GR17_GR18"),
                new RetrieveEndRoundTestCaseParam(72, "Pontoon", GameConfigsType.RNG, 601, 45303, "GR20"),
                new RetrieveEndRoundTestCaseParam(72, "Pontoon", GameConfigsType.RNG, 222241, 79317, "GR21"),
                new RetrieveEndRoundTestCaseParam(72, "Pontoon", GameConfigsType.RNG, 291192, 100, "GR22"),
                new RetrieveEndRoundTestCaseParam(72, "Pontoon", GameConfigsType.RNG, 291192, 200, "GR23"),
            };
        }
    }
}