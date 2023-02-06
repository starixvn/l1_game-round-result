using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class Win3CardsRoundResultTestCaseData : TestCaseDataProvider<RoundResultTestCaseParam>
    {
        public override List<RoundResultTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultTestCaseParam>
            {
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_9_DragonWin"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_9_DragonWin"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_10_PhoenixWin"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_10_PhoenixWin"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_11_Tie"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_11_Tie"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_12_Pair8Plus"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_12_Pair8Plus"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_13_ThreeOfAKind"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_13_ThreeOfAKind"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_14_StraightFlush"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_14_StraightFlush"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_15_Flush"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_15_Flush"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.EN, "RP_16_Straight"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 1, string.Empty, Language.VN, "RP_16_Straight"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-01", Language.EN, "RP_3_AllWinningOptions"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-01", Language.VN, "RP_3_AllWinningOptions"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 0, "2022-12-10", Language.EN, "NotExistRound"),
                new RoundResultTestCaseParam (GameType.Win3Cards, 10, string.Empty, Language.VN, "NotExistRound"),
            };
        }
    }

    public class Win3CardsRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameType.Win3Cards, "Win Three Cards", Language.EN),
                new RoundResultSelectOptionsTestCaseParam(GameType.Win3Cards, "Trác Kim Hoa", Language.VN),
            };
        }
    }
}