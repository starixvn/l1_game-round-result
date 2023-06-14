using System;
using System.Collections.Generic;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using NSubstitute;
using NSubstitute.Extensions;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Win3Cards
{
    public class Win3CardsRoundResultViewModelTests
    {
        protected readonly IJsonStringLocalizer<RoundResultViewModel> roundLocalizer;

        public Win3CardsRoundResultViewModelTests()
        {
            roundLocalizer = GetStringLocalizer();
        }

        private static IJsonStringLocalizer<RoundResultViewModel> GetStringLocalizer()
        {
            var mockLocalizer = Substitute.For<IJsonStringLocalizer<RoundResultViewModel>>();
            MockStringLocalizer(mockLocalizer, "DragonWin3Cards", "Dragon");
            MockStringLocalizer(mockLocalizer, "Phoenix", "Phoenix");
            MockStringLocalizer(mockLocalizer, "Pair8Plus", "Pair 8 Plus");
            MockStringLocalizer(mockLocalizer, "Straight", "Straight");
            MockStringLocalizer(mockLocalizer, "Flush", "Flush");
            MockStringLocalizer(mockLocalizer, "StraightFlush", "Straight Flush");
            MockStringLocalizer(mockLocalizer, "ThreeOfAKind", "Three of a Kind");
            MockStringLocalizer(mockLocalizer, "HighCard", "High Card");
            MockStringLocalizer(mockLocalizer, "Pair", "Pair");
            MockStringLocalizer(mockLocalizer, "Killer235", "235");
            return mockLocalizer;
        }

        private static void MockStringLocalizer<T>(IJsonStringLocalizer<T> stringLocalizer, string name, string value)
        {
            var localizedString = new LocalizedString(name, value);
            stringLocalizer[name].Returns(localizedString);
        }

        #region ToDataTableArray

        [Fact]
        public void ToDataTableArray_ValidData_ReturnExpected()
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsRoundResultViewModel>();
            var result = "result";
            var winningOptions = "winning options";
            viewModel.Configure().GetWinningOptionsContent(roundLocalizer).Returns(winningOptions);
            viewModel.Configure().GetResultContent(roundLocalizer).Returns(result);
            var date = new DateTime(2022, 12, 15, 1, 10, 00);
            viewModel.RoundId = 1;
            viewModel.Time = date;
            var expected = new List<string> {
                $"12/15/2022<br />01:10 AM",
                "1",
                result,
                winningOptions };

            // act
            var actual = viewModel.ToDataTableArray(roundLocalizer);

            // assert
            Assert.Equal(expected, actual);
        }

        #endregion ToDataTableArray

        #region Result

        [Fact]
        public void GetResultContent_ValiData_CallMethodWithExpectedParamAndReturnExpected()
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsRoundResultViewModel>();
            var handDragon = new Win3CardsHandViewModel
            {
                Cards = new List<PokerCardViewModel> { new PokerCardViewModel { Rank = 0, Suit = 1 } },
                HandRankId = 2,
                CardRankId = 11
            };
            var handPhoenix = new Win3CardsHandViewModel
            {
                Cards = new List<PokerCardViewModel>(),
                CardRankId = 4,
                HandRankId = 1
            };
            viewModel.Result = new Win3CardsResultViewModel
            {
                Dragon = handDragon,
                Phoenix = handPhoenix
            };
            viewModel.SettlementResult = new Win3CardsSettlementResultViewModel { Dragon = true };

            var dragonHandResult = new TagBuilder("span");
            dragonHandResult.AddCssClass("dragon");
            viewModel
                .Configure().GetHandBuilder(Arg.Any<IJsonStringLocalizer<RoundResultViewModel>>(), handDragon.Cards, handDragon.HandRank, handDragon.CardRankId, true)
                .Returns(dragonHandResult);
            var phoenixHandResult = new TagBuilder("span");
            phoenixHandResult.AddCssClass("phoenix");
            viewModel
                .Configure().GetHandBuilder(Arg.Any<IJsonStringLocalizer<RoundResultViewModel>>(), handPhoenix.Cards, handPhoenix.HandRank, handPhoenix.CardRankId, false)
                .Returns(phoenixHandResult);

            var expected = $"<div class=\"win3cards-result\">{dragonHandResult.GetHtmlString()}{phoenixHandResult.GetHtmlString()}</div>";

            // act
            var resultContent = viewModel.GetResultContent(roundLocalizer, true);

            // assert
            Assert.Equal(expected, resultContent);
        }

        [Theory]
        [MemberData(nameof(GetHandBuilderTestCaseData))]
        public void GetHandBuilder_ValidDataWithHighlightFalse_ReturnExpectedHandRankAndCallGetBuilderMethod(string handRank, int cardRankId, string expectedHandRank)
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsRoundResultViewModel>();
            var cards = new List<PokerCardViewModel>
            {
                new PokerCardViewModel{Rank=0, Suit=1},
                new PokerCardViewModel{Rank=0, Suit=0},
                new PokerCardViewModel{Rank=1, Suit=2}
            };
            var cardTagBuilder = new TagBuilder("p");
            cardTagBuilder.AddCssClass("card");
            viewModel.Configure().GetCardBuilder(Arg.Any<PokerCardViewModel>()).Returns(cardTagBuilder);
            var expected = $"<div class=\"cards\">{cardTagBuilder.GetHtmlString()}{cardTagBuilder.GetHtmlString()}{cardTagBuilder.GetHtmlString()}" +
                $"<span>{expectedHandRank}</span></div>";

            // act
            var result = viewModel.GetHandBuilder(roundLocalizer, cards, handRank, cardRankId, false);

            // asert
            viewModel.Received(3).GetCardBuilder(Arg.Any<PokerCardViewModel>());
            Assert.Equal(expected, result.GetHtmlString());
        }

        [Theory]
        [MemberData(nameof(GetHandBuilderTestCaseData))]
        public void GetHandBuilder_ValidDataWithHighlightTrue_ReturnExpectedHandRankAndCallGetBuilderMethod(string handRank, int cardRankId, string expectedHandRank)
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsRoundResultViewModel>();
            var cards = new List<PokerCardViewModel>
            {
                new PokerCardViewModel{Rank=0, Suit=1},
                new PokerCardViewModel{Rank=0, Suit=0},
                new PokerCardViewModel{Rank=1, Suit=2}
            };
            var cardTagBuilder = new TagBuilder("p");
            cardTagBuilder.AddCssClass("card");
            viewModel.Configure().GetCardBuilder(Arg.Any<PokerCardViewModel>()).Returns(cardTagBuilder);
            var expected = $"<div class=\"cards\">{cardTagBuilder.GetHtmlString()}{cardTagBuilder.GetHtmlString()}{cardTagBuilder.GetHtmlString()}" +
                $"<span class=\"bold\">{expectedHandRank}</span></div>";

            // act
            var result = viewModel.GetHandBuilder(roundLocalizer, cards, handRank, cardRankId, true);

            // asert
            viewModel.Received(3).GetCardBuilder(Arg.Any<PokerCardViewModel>());
            Assert.Equal(expected, result.GetHtmlString());
        }

        public static IEnumerable<object[]> GetHandBuilderTestCaseData()
        {
            yield return new object[] { "HighCard", 2, "High Card 3" };
            yield return new object[] { "HighCard", 10, "High Card J" };
            yield return new object[] { "Pair", 0, "Pair A" };
            yield return new object[] { "Pair", 12, "Pair K" };
            yield return new object[] { "Pair", 9, "Pair 10" };
            yield return new object[] { "Straight", -1, "Straight" };
            yield return new object[] { "Flush", -1, "Flush" };
            yield return new object[] { "StraightFlush", -1, "Straight Flush" };
            yield return new object[] { "ThreeOfAKind", -1, "Three of a Kind" };
            yield return new object[] { "Killer235", -1, "235" };
        }

        [Theory]
        [InlineData(0, 0, "A")]
        [InlineData(1, 1, "2")]
        [InlineData(2, 2, "3")]
        [InlineData(3, 3, "4")]
        [InlineData(4, 2, "5")]
        [InlineData(5, 1, "6")]
        [InlineData(6, 2, "7")]
        [InlineData(7, 0, "8")]
        [InlineData(8, 2, "9")]
        [InlineData(9, 1, "10")]
        [InlineData(10, 2, "J")]
        [InlineData(11, 3, "Q")]
        [InlineData(12, 0, "K")]
        public void GetCardBuilder_ValidCard_ReturnExpectedTag(byte rank, byte suit, string expectedRank)
        {
            // arrange
            var card = new PokerCardViewModel { Rank = rank, Suit = suit };
            var expected = $"<div class=\"card card-type-{suit}\"><span>{expectedRank}</span><img class=\"img\" src=\"/scss/images/card_{suit}.png\"></img></div>";

            // act
            var actual = new Win3CardsRoundResultViewModel().GetCardBuilder(card);

            // assert
            Assert.Equal(expected, actual.GetHtmlString());
        }

        #endregion Result

        #region Winning Options

        [Theory]
        [MemberData(nameof(WinningOptionsTestCaseData))]
        public void GetWinningOptionsContent_ValidData_ReturnMatchedSettlementResult(Win3CardsSettlementResultViewModel settlementResult, string expected)
        {
            // arrange
            var viewModel = new Win3CardsRoundResultViewModel { SettlementResult = settlementResult };

            // act
            var actual = viewModel.GetWinningOptionsContent(roundLocalizer);

            // assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> WinningOptionsTestCaseData()
        {
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true },
                "Dragon"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true },
                "Phoenix"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true, Straight = true },
                "Dragon, Pair 8 Plus, Straight"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true, Pair8Plus = true, Flush = true },
                "Phoenix, Pair 8 Plus, Flush"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true, StraightFlush = true },
                "Dragon, Pair 8 Plus, Straight Flush"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true, Pair8Plus = true, ThreeOfAKind =true },
                "Phoenix, Pair 8 Plus, Three of a Kind"
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel(),
                string.Empty
                };
        }

        #endregion Winning Options

        #region IsWinningChoice

        [Theory]
        [MemberData(nameof(IsWinningChoiceTestCaseData))]
        public void IsWinningChoice_ReturnExpected(Win3CardsSettlementResultViewModel settlementResult, string choice, bool expected)
        {
            // arrange
            var viewModel = new Win3CardsRoundResultViewModel { SettlementResult = settlementResult };

            // act
            var actual = viewModel.IsWinningChoice(choice);

            // assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> IsWinningChoiceTestCaseData()
        {
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true },
                "Dragon",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true },
                "Dragon",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true },
                "DragonWin3Cards",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true },
                "DragonWin3Cards",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true },
                "Phoenix",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true },
                "Phoenix",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true,  Pair8Plus = true,  ThreeOfAKind =true },
                "ThreeOfAKind",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{Phoenix = true },
                "ThreeOfAKind",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true },
                "Pair8Plus",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true },
                "Pair8Plus",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true, Straight = true },
                "Straight",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true, Pair8Plus = true, Flush = true },
                "Straight",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true, Flush = true },
                "Flush",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true, Pair8Plus = true, ThreeOfAKind = true },
                "Flush",
                false
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Dragon= true, Pair8Plus = true, StraightFlush = true },
                "StraightFlush",
                true
                };
            yield return new object[] {
                new Win3CardsSettlementResultViewModel{ Phoenix = true, Pair8Plus = true, Straight = true },
                "StraightFlush",
                false
                };
        }

        #endregion IsWinningChoice
    }
}