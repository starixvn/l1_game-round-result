using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FootballDiceEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.FootballDice,"FootballDice", GameConfigsType.RNG, "291192", 1, "GR09_GR10_GR11_GR12_GR18"),
                new RetrieveEndRoundTestCaseParam((int)GameType.FootballDice,"FootballDice", GameConfigsType.RNG, "291192", 2, "GR14_GR15"),
                new RetrieveEndRoundTestCaseParam((int)GameType.FootballDice,"FootballDice", GameConfigsType.RNG, "291192", 1, "GR17"),
            };
        }
    }
}