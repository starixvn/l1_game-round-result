using GameRoundResult.Web.Models;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Models.Win3Cards
{
    public class Win3CardsBetLogViewModelTests
    {
        [Theory]
        [InlineData("dragon", "DragonWin3Cards")]
        [InlineData("phoenix", "Phoenix")]
        [InlineData("pair8Plus", "Pair8Plus")]
        [InlineData("straight", "Straight")]
        [InlineData("flush", "Flush")]
        [InlineData("threeOfAKind", "ThreeOfAKind")]
        public void ChoiceDisplay_IsDragon_ReturnExpected(string choice, string expected)
        {
            // arrange
            var viewModel = new Win3CardsBetLogViewModel { Choice = choice };

            // act
            var actual = viewModel.ChoiceDisplay;

            // assert
            Assert.Equal(expected, actual);
        }
    }
}