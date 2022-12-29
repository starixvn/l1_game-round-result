using GameRoundResult.Web.Models;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Base
{
    public class GameTicketViewModelTests
    {
        [Fact]
        public void WinLossClassName_WinLossGreaterThan0_ReturnEmpty()
        {
            // arrange
            var viewModel = new GameTicketViewModel { BetWin = 100, TotalBet = 50 };

            // act
            var actual = viewModel.WinLossRowClassName;

            // assert
            Assert.Equal(string.Empty, actual);
        }

        [Fact]
        public void WinLossClassName_WinLossLessThan0_ReturnTextRed()
        {
            // arrange
            var viewModel = new GameTicketViewModel { BetWin = 0, TotalBet = 50 };

            // act
            var actual = viewModel.WinLossRowClassName;

            // assert
            Assert.Equal("text-red", actual);
        }
    }
}