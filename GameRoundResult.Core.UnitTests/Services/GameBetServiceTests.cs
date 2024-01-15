using AutoFixture;
using AutoFixture.Xunit2;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Services
{
    public class GameBetServiceTests
    {
        private readonly GameBetService gameBetService;
        private readonly IGameBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public GameBetServiceTests()
        {
            gameBetRepository = Substitute.For<IGameBetRepository>();
            gameBetService = new GameBetService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GameBetService_ReturnCorrectResult(long roundId, string memberId, bool freeBet, string partnerId)
        {
            //Arrnage
            var roundEntity = fixture.Create<SeDieRound>();
            var betEntity = fixture.Create<SeDieBet>();
            gameBetRepository.GetAsync<SeDieRound, SeDieBet>(roundId, memberId, freeBet, partnerId).Returns((roundEntity, betEntity));

            //Act
            var result = await gameBetService.GetAsync<SeDieRound, SeDieBet>(roundId, memberId, freeBet, partnerId);

            //Assert
            Assert.StrictEqual(roundEntity, result.Item1);
            Assert.StrictEqual(betEntity, result.Item2);
        }


        [Theory, AutoData]
        public async Task GameBetService_WithBetLogs_ReturnCorrectResult(long roundId, string memberId, bool freeBet, string partnerId)
        {
            //Arrnage
            var roundEntity = fixture.Create<SicBoRound>();
            var betEntity = fixture.Create<SicBoOne>();
            var betLogsEntities = fixture.CreateMany<SicBoBet>();
            gameBetRepository.GetAsync<SicBoRound, SicBoOne, SicBoBet>(roundId, memberId, freeBet, partnerId).Returns((roundEntity, betLogsEntities, betEntity));

            //Act
            var result = await gameBetService.GetAsync<SicBoRound, SicBoOne, SicBoBet>(roundId, memberId, freeBet, partnerId);

            //Assert
            Assert.StrictEqual(roundEntity, result.Item1);
            Assert.StrictEqual(betEntity, result.Item3);
            Assert.Equal(betLogsEntities, result.Item2);
        }
    }
}
