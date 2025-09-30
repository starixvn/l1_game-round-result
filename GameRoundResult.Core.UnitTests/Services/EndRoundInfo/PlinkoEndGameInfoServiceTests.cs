using AutoFixture;
using GameRoundResult.Core.Database.Entities;
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
    public class PlinkoEndGameInfoServiceTests
    {
        private readonly IPlinkoGameBetRepository betRepository;
        private readonly PlinkoEndGameInfoServiceMock endGameInfoService;
        private readonly Fixture fixture;

        public PlinkoEndGameInfoServiceTests()
        {
            betRepository = Substitute.For<IPlinkoGameBetRepository>();
            endGameInfoService = new PlinkoEndGameInfoServiceMock(betRepository);
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
            endGameInfoService.Round = new PlinkoGameRound();
            endGameInfoService.Round.TotalAmount = 0; // No bets

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
            var betAmount = fixture.Create<decimal>();
            var betWin = fixture.Create<decimal>();
            var endTime = new DateTime(2022, 10, 20);

            endGameInfoService.Round = new PlinkoGameRound
            {
                Time = endTime,
                TotalAmount = betAmount,
                BetWin = betWin
            };

            var expectedInfo = new EndRoundInfoResult
            {
                EndTime = endTime,
                ValidBetAmount = betAmount,
                TotalAmount = betAmount,
                TotalWin = betWin
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(expectedInfo.EndTime, actualResult.EndTime);
            Assert.Equal(expectedInfo.ValidBetAmount, actualResult.ValidBetAmount);
            Assert.Equal(expectedInfo.TotalAmount, actualResult.TotalAmount);
            Assert.Equal(expectedInfo.TotalWin, actualResult.TotalWin);
        }

        [Fact]
        public async Task GetAsync_WhenHaveSettlementResult_ReturnCorrectData()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            var betAmount = fixture.Create<decimal>();
            var betWin = fixture.Create<decimal>();
            var endTime = new DateTime(2022, 10, 20);
            var slotIndex = fixture.Create<int>();
            var multiplier = fixture.Create<double>();

            endGameInfoService.Round = new PlinkoGameRound
            {
                Time = endTime,
                TotalAmount = betAmount,
                BetWin = betWin,
                SettlementResult = new PlinkoSettlement
                {
                    SlotIndex = slotIndex,
                    Multiplier = multiplier
                }
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(endTime, actualResult.EndTime);
            Assert.Equal(betAmount, actualResult.ValidBetAmount);
            Assert.Equal(betAmount, actualResult.TotalAmount);
            Assert.Equal(betWin, actualResult.TotalWin);
        }

        [Fact]
        public async Task GetAsync_WhenReachMaxWin_ReturnCorrectData()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            var betAmount = fixture.Create<decimal>();
            var betWin = fixture.Create<decimal>();
            var endTime = new DateTime(2022, 10, 20);

            endGameInfoService.Round = new PlinkoGameRound
            {
                Time = endTime,
                TotalAmount = betAmount,
                BetWin = betWin,
                ReachMaxWin = true
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(endTime, actualResult.EndTime);
            Assert.Equal(betAmount, actualResult.ValidBetAmount);
            Assert.Equal(betAmount, actualResult.TotalAmount);
            Assert.Equal(betWin, actualResult.TotalWin);
        }

        [Fact]
        public async Task GetAsync_WhenHaveZeroBetAmount_ReturnSB1001Error()
        {
            // Arrange
            var request = new RetrieveEndGameInfoRequest();
            endGameInfoService.Round = new PlinkoGameRound
            {
                Time = new DateTime(2022, 10, 20),
                TotalAmount = 0,
                BetWin = 0
            };

            // Act
            var actualResult = await endGameInfoService.GetAsync(request);

            //Assert
            Assert.Equal(EndRoundInfoError.SB1001, actualResult);
        }
    }
}
