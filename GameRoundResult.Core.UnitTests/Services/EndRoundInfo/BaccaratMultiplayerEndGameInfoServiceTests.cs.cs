using AutoFixture;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class BaccaratMultiplayerEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly BaccaratMultiplayerEndGameInfoServiceMock service;
        private readonly Fixture fixture;

        public BaccaratMultiplayerEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            service = new BaccaratMultiplayerEndGameInfoServiceMock(database);
            fixture = new Fixture();
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
            service.Round = new BaccaratMultiplayerRound();
            service.Bets = Enumerable.Empty<BaccaratMultiplayerBet>();

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
            service.Round = new BaccaratMultiplayerRound { Time = new DateTime(2025, 8, 7) };

            var bet = new BaccaratMultiplayerBet
            {
                Banker = fixture.Create<decimal>(),
                Player = fixture.Create<decimal>(),
                Tie = fixture.Create<decimal>(),
                AnyPair = fixture.Create<decimal>(),
                Betwin = fixture.Create<decimal>()
            };

            service.Bets = new List<BaccaratMultiplayerBet> { bet };

            var expectedTotal = bet.Banker + bet.Player + bet.Tie + bet.AnyPair;

            // Act
            var result = await service.GetAsync(request);

            // Assert
            Assert.Equal(expectedTotal, result.TotalAmount);
        }
    }
}
