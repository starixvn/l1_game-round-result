using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.SlotGames;
using NSubstitute;
using Xunit;

namespace GameRoundResult.Core.UnitTests.Services
{
    public class SlotGameTicketServiceTests
    {
        private readonly ISlotGameTicketService gameBetService;
        private readonly ISlotGameBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public SlotGameTicketServiceTests()
        {
            gameBetRepository = Substitute.For<ISlotGameBetRepository>();
            gameBetService = new SlotGameTicketService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(long roundId, string playerId, string operatorId, string gameName)
        {
            //Arrnage
            var roundEntity = fixture.Create<SlotGameRound>();
            gameBetRepository.GetAsync<SlotGameRound>(roundId, playerId, operatorId, gameName).Returns(roundEntity);

            //Act
            var result = await gameBetService.GetAsync(roundId, playerId, operatorId, gameName);

            //Assert
            Assert.StrictEqual(roundEntity, result);
            await gameBetRepository.Received(1).GetAsync<SlotGameRound>(roundId, playerId, operatorId, gameName);
        }
    }
}