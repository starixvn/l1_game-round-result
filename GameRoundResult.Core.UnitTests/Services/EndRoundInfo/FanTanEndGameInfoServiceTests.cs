using System.Threading.Tasks;
using AutoFixture;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using MongoDB.Driver;
using NSubstitute;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GameRoundResult.Core.UnitTests.Services.EndRoundInfo
{
    public class FanTanEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly FanTanEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public FanTanEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            endGameInfoService = new FanTanEndGameInfoServiceMock(database);
            fixture = new Fixture();
        }

        [Fact]
        public async Task GetAsync_WhenNotHaveRound_ReturnSB1001Error()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = null;

            // Act
            var actualResult = await endGameInfoService.GetAsync(request, string.Empty);

            //Assert
            Assert.Equal(EndRoundInfoError.SB1001, actualResult);
        }

        [Fact]
        public async Task GetAsync_WhenNotHaveBets_ReturnSB1001Error()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = new FanTanRound();
            endGameInfoService.Bets = Enumerable.Empty<FanTanBet>();

            // Act
            var actualResult = await endGameInfoService.GetAsync(request, string.Empty);

            //Assert
            Assert.Equal(EndRoundInfoError.SB1001, actualResult);
        }

        [Fact]
        public async Task GetAsync_WhenHaveData_ReturnEndGameInfo()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = new FanTanRound
            {
                Time = new DateTime(2022, 10, 20)
            };

            var betAmount = fixture.Create<decimal>();

            endGameInfoService.Bets = new List<FanTanBet> {
                new FanTanBet { Odd  = betAmount, TotalAmount = betAmount }
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endGameInfoService.Round.Time,
                ValidBetAmount = betAmount,
                TotalAmount = betAmount
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request, string.Empty);

            //Assert
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
        }
    }
}
