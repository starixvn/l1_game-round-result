using AutoFixture;
using GameRoundResult.Core.Database.Entities.SeDieMultiplayer;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class SeDieMultiplayerEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly SeDieMultiplayerEndGameInfoServiceMock service;
        private readonly Fixture fixture;

        public SeDieMultiplayerEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            service  = new SeDieMultiplayerEndGameInfoServiceMock(database);
            fixture  = new Fixture();
        }

        [Fact]
        public async Task GetAsync_NoRound_Returns_SB1001()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            service.Round = null;

            // Act
            var result = await service.GetAsync(request);

            // Assert
            Assert.Equal(EndRoundInfoError.SB1001, result);
        }

        [Fact]
        public async Task GetAsync_NoBets_Returns_SB1001()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            service.Round = new SeDieMultiplayerRound();
            service.Bets  = Enumerable.Empty<SeDieMultiplayerBet>();

            // Act
            var result = await service.GetAsync(request);

            // Assert
            Assert.Equal(EndRoundInfoError.SB1001, result);
        }

        [Fact]
        public async Task GetAsync_HasData_ReturnsAggregatedInfo()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            service.Round = new SeDieMultiplayerRound { Time = new DateTime(2025, 8, 7) };

            var bet = new SeDieMultiplayerBet
            {
                Odd        = fixture.Create<decimal>(),
                Even       = fixture.Create<decimal>(),
                TwoRed     = fixture.Create<decimal>(),
                ThreeRed   = fixture.Create<decimal>(),
                FourRed    = fixture.Create<decimal>(),
                ThreeWhite = fixture.Create<decimal>(),
                FourWhite  = fixture.Create<decimal>(),
                Betwin     = fixture.Create<decimal>()
            };

            service.Bets = new List<SeDieMultiplayerBet> { bet };

            var expectedTotal = bet.Odd + bet.Even + bet.TwoRed + bet.ThreeRed + bet.FourRed + bet.ThreeWhite + bet.FourWhite;

            // Act
            var result = await service.GetAsync(request);

            // Assert
            Assert.Equal(expectedTotal, result.TotalAmount);
        }
    }
}
