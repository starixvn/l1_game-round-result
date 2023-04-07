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
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, "2022-12-01", Language.EN, "RP_9_DragonWin"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, "2022-12-01", Language.VN, "RP_9_DragonWin"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_10_PhoenixWin"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_10_PhoenixWin"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_11_Tie"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_11_Tie"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_12_Pair8Plus"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_12_Pair8Plus"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, "2022-12-01", Language.EN, "RP_13_ThreeOfAKind"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, "2022-12-01", Language.VN, "RP_13_ThreeOfAKind"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_14_StraightFlush"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_14_StraightFlush"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_15_Flush"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_15_Flush"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.EN, "RP_16_Straight"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 1, string.Empty, Language.VN, "RP_16_Straight"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 0, "2022-12-01", Language.EN, "RP_3_AllWinningOptions"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 0, "2022-12-01", Language.VN, "RP_3_AllWinningOptions"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 0, "2022-12-10", Language.EN, "NotExistRound"),
                new RoundResultTestCaseParam (GameId.WinThreeCards, 10, string.Empty, Language.VN, "NotExistRound"),
            };
        }
    }

    public class Win3CardsRoundResultSelectOptionTestCaseData : TestCaseDataProvider<RoundResultSelectOptionsTestCaseParam>
    {
        public override List<RoundResultSelectOptionsTestCaseParam> GetTestCaseParams()
        {
            return new List<RoundResultSelectOptionsTestCaseParam>
            {
                new RoundResultSelectOptionsTestCaseParam(GameId.WinThreeCards, "Win Three Cards", Language.EN),
                new RoundResultSelectOptionsTestCaseParam(GameId.WinThreeCards, "Trác Kim Hoa", Language.VN),
            };
        }
    }
}