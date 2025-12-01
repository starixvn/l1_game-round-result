using AutoFixture;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.Ludo;
using GameRoundResult.Core.Database.Repository;
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
    public class LudoEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly LudoEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public LudoEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            endGameInfoService = new LudoEndGameInfoServiceMock(database);
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
            endGameInfoService.Round = new LudoRound();
            endGameInfoService.Bets = Enumerable.Empty<LudoBet>();

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
            endGameInfoService.Round = new LudoRound
            {
                Time = new DateTime(2022, 10, 20)
            };

            endGameInfoService.Bets = new List<LudoBet> {
                new LudoBet { Odd = 2, Kick = 10, Release = 1, GoStable = 1, Big = 1, Betwin = 1 }
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endGameInfoService.Round.Time,
                ValidBetAmount = 15,
                TotalAmount = 15,
                TotalWin = 1
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
        }
    }
}
