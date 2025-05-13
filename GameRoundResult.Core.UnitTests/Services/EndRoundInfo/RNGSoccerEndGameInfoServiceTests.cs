using AutoFixture;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Database.Entities.RNGSoccer;
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
    public class RNGSoccerEndGameInfoServiceTests
    {
        private readonly IMongoDatabase database;
        private readonly RNGSoccerEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public RNGSoccerEndGameInfoServiceTests()
        {
            database = Substitute.For<IMongoDatabase>();
            endGameInfoService = new RNGSoccerEndGameInfoServiceMock(database);
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
            endGameInfoService.Round = new RNGSoccerRound();
            endGameInfoService.Bets = Enumerable.Empty<RNGSoccerBet>();

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
            endGameInfoService.Round = new RNGSoccerRound
            {
                Time = new DateTime(2022, 10, 20)
            };

            endGameInfoService.Bets = new List<RNGSoccerBet> {
                new RNGSoccerBet { Home = 2, Away = 0, Draw = 1, Betwin = 1 },
                new RNGSoccerBet { Home = 0, Away = 1, Draw = 3, Betwin = 2 }
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endGameInfoService.Round.Time,
                ValidBetAmount = 6,
                TotalAmount = 6,
                TotalWin = 3
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
        }
    }
}
