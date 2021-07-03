using System;
using GameRoundResult.Core.Constants;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Constants
{
    public class RouletteTests
    {
        private static readonly byte[] ExpectedRedNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

        [Fact]
        public void RedNumbers_Always_Return_ExpectedValues()
            => Assert.Equal(ExpectedRedNumbers, Roulette.RedNumbers);
    }
}

