using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class DragonTigerFightBetHistoryTestCaseData : TestCaseDataProvider<BetHistoryTestCaseParam>
    {
        public override List<BetHistoryTestCaseParam> GetTestCaseParams()
            => new List<BetHistoryTestCaseParam>
            {                
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "LosingRound"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "FractionalOdds"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "NotExistBet"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "NotExistRound"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR1_DragonWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR4_DragonLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR5_TigerWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR8_TigerLose"),

            };
    }
}