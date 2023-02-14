using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam(59, "FruitSlot", 123, 1, "1_ExistBet"),
                new RetrieveEndRoundTestCaseParam(59, "FruitSlot", 123, 1000, "NotExistRound"),
            };
        }
    }
}