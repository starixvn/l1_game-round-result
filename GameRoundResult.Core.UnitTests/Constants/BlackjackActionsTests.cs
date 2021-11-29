using GameRoundResult.Core.Constants;
using Xunit;

namespace GameRoundResult.Core.Tests.Constants
{
    public class BlackjackActionsTests
    {
        [Theory]
        [InlineData("split")]
        public void BlackjackAction_Split_Returns_ExpectedString(string @action)
        {
            Assert.Equal(BlackjackAction.Split, action);
        }

        [Theory]
        [InlineData("stand")]
        public void BlackjackAction_Stand_Returns_ExpectedString(string @action)
        {
            Assert.Equal(BlackjackAction.Stand, action);
        }

        [Theory]
        [InlineData("hit")]
        public void BlackjackAction_Hit_Returns_ExpectedString(string @action)
        {
            Assert.Equal(BlackjackAction.Hit, action);
        }

        [Theory]
        [InlineData("double")]
        public void BlackjackAction_Double_Returns_ExpectedString(string @action)
        {
            Assert.Equal(BlackjackAction.Double, action);
        }
    }
}