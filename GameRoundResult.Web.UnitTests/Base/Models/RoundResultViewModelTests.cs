using System;
using GameRoundResult.Web.Models;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Base
{
    public class RoundResultViewModelTests
    {
        [Fact]
        public void ToDataTableArray_ReturnExpected()
        {
            // arrange
            var viewModel = new RoundResultViewModel
            {
                Time = new DateTime(2022, 12, 30, 10, 30, 20),
                RoundId = 1
            };
            var expected = new[] { "12/30/2022<br />10:30 AM", "1" };

            // act
            var actual = viewModel.ToDataTableArray(null);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}