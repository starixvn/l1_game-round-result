using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotEndRoundTestCaseData : TestCaseDataProvider<EndRoundTestCaseParam>
    {
        public override List<EndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<EndRoundTestCaseParam>
            {
                new EndRoundTestCaseParam(GameType.FruitSlot, 123, 1, 10, 20, 10, new DateTimeOffset(2022, 10, 25, 07, 56, 59, new TimeSpan()), "0", null, "1_ExistBet"),
                new EndRoundTestCaseParam(GameType.FruitSlot, 123, 1000, 0, 0, 0, null, "SB1001", "The game round does not exist.", "NotExistRound"),
            };
        }
    }
}