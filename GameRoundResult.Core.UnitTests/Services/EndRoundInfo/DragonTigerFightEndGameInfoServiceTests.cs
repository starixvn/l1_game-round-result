using AutoFixture;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
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
    public class DragonTigerFightEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly DragonTigerFightEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public DragonTigerFightEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            endGameInfoService = new DragonTigerFightEndGameInfoServiceMock(database);
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
            endGameInfoService.Round = new DragonTigerFightRound();
            endGameInfoService.Bets = Enumerable.Empty<DragonTigerFightOne>();

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
            endGameInfoService.Round = new DragonTigerFightRound
            {
                Time = new DateTime(2022, 10, 20)
            };

            endGameInfoService.Bets = new List<DragonTigerFightOne> {
                new DragonTigerFightOne { Dragon = 2, Tiger = 0, Tie = 1, BlackDragon = 1, RedDragon = 1, BlackTiger = 1, RedTiger = 1, Betwin = 1 },
                new DragonTigerFightOne { Dragon = 0, Tiger = 1, Tie = 3, BlackDragon = 1, RedDragon = 1, BlackTiger = 1, RedTiger = 1, Betwin = 2 }
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endGameInfoService.Round.Time,
                ValidBetAmount = 15,
                TotalAmount = 15,
                TotalWin = 3
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
        }
    }
}
