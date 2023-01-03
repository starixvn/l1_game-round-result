using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsEndRoundTestCaseData : TestCaseDataProvider<EndRoundTestCaseParam>
    {
        public override List<EndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<EndRoundTestCaseParam>
            {
                new EndRoundTestCaseParam(GameType.Win3Cards, 123, 1, 100, 195, 100, new DateTimeOffset(2022, 12, 01, 07, 00, 00, new TimeSpan()), "0", null, "RER_1_2_3_ExistBet"),
                new EndRoundTestCaseParam(GameType.Win3Cards, 123, 2, 0, 0, 0, null, "SB1001", "The game round does not exist.", "NotExistRound"),
                new EndRoundTestCaseParam(GameType.Win3Cards, 123, 3, 1500, 0, 1500, new DateTimeOffset(2022, 12, 01, 09, 00, 00, new TimeSpan()), "0", null, "Losing"),
                new EndRoundTestCaseParam(GameType.Win3Cards, 123, 4, 0, 0, 0, null, "SB1001", "The game round does not exist.", "RER_5_RunningRound"),
                new EndRoundTestCaseParam(GameType.Win3Cards, 123, 5, 0, 0, 0, null, "SB1001", "The game round does not exist.", "RER_6_NotExistBet"),
            };
        }
    }
}