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
    public class MiniRouletteEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly MiniRouletteEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public MiniRouletteEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            endGameInfoService = new MiniRouletteEndGameInfoServiceMock(database);
            fixture = new Fixture();
        }

        [Fact]
        public async Task GetAsync_WhenNotHaveRound_ReturnSB1001Error()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = null;

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(EndRoundInfoError.SB1001, actualResult);
        }

        [Fact]
        public async Task GetAsync_WhenNotHaveBets_ReturnSB1001Error()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = new MiniRouletteRound();
            endGameInfoService.Bets = Enumerable.Empty<MiniRouletteBet>();

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(EndRoundInfoError.SB1001, actualResult);
        }

        [Fact]
        public async Task GetAsync_WhenHaveData_ReturnEndGameInfo()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = new MiniRouletteRound
            {
                Time = new DateTime(2022, 10, 20)
            };

            var betAmount = fixture.Create<decimal>();

            endGameInfoService.Bets = new List<MiniRouletteBet> {
                new MiniRouletteBet { TotalAmount = betAmount }
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endGameInfoService.Round.Time,
                ValidBetAmount = betAmount,
                TotalAmount = betAmount
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
        }
    }
}
