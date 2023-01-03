using System.Collections.Generic;
using GameRoundResult.Web.Models;
using NSubstitute;
using NSubstitute.Extensions;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Win3Cards
{
    public class Win3CardsTicketViewModelTests
    {
        #region GetBetLogWin

        [Theory]
        [InlineData(1000, "2,000")]
        [InlineData(100, "200")]
        public void GetBetLogWin_IsWinning_ReturnExpected(decimal amount, string expected)
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsTicketViewModel>();
            var roundResult = Substitute.For<Win3CardsRoundResultViewModel>();
            roundResult.Configure().IsWinningChoice("Phoenix").Returns(true);
            viewModel.RoundResult = roundResult;
            viewModel.Odds = new Dictionary<string, decimal>
            {
                ["phoenix"] = 2
            };
            var bet = Substitute.ForPartsOf<Win3CardsBetLogViewModel>();
            bet.Choice = "phoenix";
            bet.Amount = amount;
            bet.Configure().ChoiceDisplay.Returns("Phoenix");

            // act
            var actual = viewModel.GetBetLogWin(bet);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetBetLogWin_IsLosing_ReturnExpected()
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsTicketViewModel>();
            var roundResult = Substitute.For<Win3CardsRoundResultViewModel>();
            roundResult.Configure().IsWinningChoice("Phoenix").Returns(false);
            viewModel.RoundResult = roundResult;
            viewModel.Odds = new Dictionary<string, decimal>
            {
                ["phoenix"] = 2
            };
            var bet = Substitute.ForPartsOf<Win3CardsBetLogViewModel>();
            bet.Choice = "phoenix";
            bet.Amount = 10;
            bet.Configure().ChoiceDisplay.Returns("Phoenix");

            // act
            var actual = viewModel.GetBetLogWin(bet);

            // assert
            Assert.Equal("0", actual);
        }

        #endregion GetBetLogWin

        #region GetRowBetClass

        [Fact]
        public void GetRowBetClass_WhenLose_ReturnEmpty()
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsTicketViewModel>();
            var roundResult = Substitute.For<Win3CardsRoundResultViewModel>();
            roundResult.Configure().IsWinningChoice("Phoenix").Returns(false);
            viewModel.RoundResult = roundResult;

            // act
            var actual = viewModel.GetRowBetClass("Phoenix");

            // assert
            Assert.Equal(string.Empty, actual);
        }

        [Fact]
        public void GetRowBetClass_WhenWin_ReturnBold()
        {
            // arrange
            var viewModel = Substitute.ForPartsOf<Win3CardsTicketViewModel>();
            var roundResult = Substitute.For<Win3CardsRoundResultViewModel>();
            roundResult.Configure().IsWinningChoice("Phoenix").Returns(true);
            viewModel.RoundResult = roundResult;

            // act
            var actual = viewModel.GetRowBetClass("Phoenix");

            // assert
            Assert.Equal("bold", actual);
        }

        #endregion GetRowBetClass
    }
}