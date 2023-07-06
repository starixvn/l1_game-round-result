using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class DragonTigerFightEndRoundTestCaseData : TestCaseDataProvider<RetrieveEndRoundTestCaseParam>
    {
        public override List<RetrieveEndRoundTestCaseParam> GetTestCaseParams()
        {
            return new List<RetrieveEndRoundTestCaseParam>
            {
                new RetrieveEndRoundTestCaseParam((int)GameType.DragonTigerFight,"DragonTigerFight", 123, 1, "RER_1_2_3_ExistBet"),
                new RetrieveEndRoundTestCaseParam((int)GameType.DragonTigerFight,"DragonTigerFight", 123, 2, "NotExistRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.DragonTigerFight,"DragonTigerFight", 123, 3, "Losing"),
                new RetrieveEndRoundTestCaseParam((int)GameType.DragonTigerFight,"DragonTigerFight", 123, 4, "RER_5_RunningRound"),
                new RetrieveEndRoundTestCaseParam((int)GameType.DragonTigerFight,"DragonTigerFight", 123, 5, "RER_6_NotExistBet"),
            };
        }
    }
}