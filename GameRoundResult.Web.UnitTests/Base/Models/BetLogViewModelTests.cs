using System;
using GameRoundResult.Web.Models;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Base
{
    public class BetLogViewModelTests
    {
        [Fact]
        public void DateDisplay_ReturnExpected()
        {
            // arrange
            var viewModel = new BetLogViewModel
            {
                Time = new DateTime(2022, 12, 30, 10, 30, 20)
            };
            var expected = "12/30/2022";

            // act
            var actual = viewModel.DateDisplay;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimeDisplay_ReturnExpected()
        {
            // arrange
            var viewModel = new BetLogViewModel
            {
                Time = new DateTime(2022, 12, 30, 10, 30, 20)
            };
            var expected = "10:30:20 AM";

            // act
            var actual = viewModel.TimeDisplay;

            // assert
            Assert.Equal(expected, actual);
        }
    }
}