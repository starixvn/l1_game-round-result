using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CascadingSlotGames;
using NSubstitute;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Services
{
    public class BaseCascadingSlotTicketServiceTests
    {
        private readonly ICascadingSlotTicketService gameBetService;
        private readonly ICascadingSlotBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public BaseCascadingSlotTicketServiceTests()
        {
            gameBetRepository = Substitute.For<ICascadingSlotBetRepository>();
            gameBetService = new CascadingSlotTicketService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(long roundId, string memberId, string operatorId, string gameName)
        {
            //Arrnage
            var roundEntity = fixture.Create<BaseCascadingSlotRoundEntity>();
            var totalMultiplierEntity = fixture.Create<BaseCascadingSlotTotalMultiplierEntity>();
            gameBetRepository.GetAsync(roundId, memberId, operatorId, gameName).Returns((roundEntity, totalMultiplierEntity));

            //Act
            var result = await gameBetService.GetAsync(roundId, memberId, operatorId, gameName);

            //Assert
            Assert.StrictEqual(roundEntity, result.Item1);
            Assert.StrictEqual(totalMultiplierEntity, result.Item2);
            await gameBetRepository.Received(1).GetAsync(roundId, memberId, operatorId, gameName);
        }
    }
}