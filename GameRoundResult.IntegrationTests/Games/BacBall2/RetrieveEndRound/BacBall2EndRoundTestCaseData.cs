using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests.Games.BacBall2.RetrieveEndRound
{
    public class BacBall2EndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.BacBall2,"BacBall2", GameConfigsType.SlotRNG, "123", 3, "GR31_GR32_GR33_GR40_01_RoundIsSettle_Losing"),
                new RetrieveEndRoundTestCaseParam((int)GameType.BacBall2,"BacBall2", GameConfigsType.SlotRNG, "123", 2, "GR31_GR32_GR33_GR40_02_RoundIsSettle_Winning"),
                new RetrieveEndRoundTestCaseParam((int)GameType.BacBall2,"BacBall2", GameConfigsType.SlotRNG, "123", 4, "GR35_RunningRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.BacBall2,"BacBall2", GameConfigsType.SlotRNG, "123", 4, "GR36_RoundIsSettle_NotExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.BacBall2,"BacBall2", GameConfigsType.SlotRNG, "123", 2, "GR37_GR39_NotExistRound"),
            };
        }
    }
}