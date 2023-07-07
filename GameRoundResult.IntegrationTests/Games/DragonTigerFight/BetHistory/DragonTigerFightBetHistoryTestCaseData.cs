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
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR01_DragonWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR04_DragonLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR05_TigerWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR08_TigerLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR11_BlackDragonWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR12_BlackDragonLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR13_RedDragonWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR14_RedDragonLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR15_BlackTigerWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR16_BlackTigerLose"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR17_RedTigerWin"),
                new BetHistoryTestCaseParam((int)GameType.DragonTigerFight, "DragonTigerFight", 9862439, 21122, Language.EN, "RR18_RedTigerLose"),

            };
    }
}