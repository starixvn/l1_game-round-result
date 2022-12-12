using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
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
        public async Task GetAsync_ReturnCorrectResult(long roundId, int memberId, string operatorId)
        {
            //Arrnage
            var roundEntity = fixture.Create<SlotGameRound>();
            var gameConfigs = fixture.Create<GameConfigs>();
            gameBetRepository.GetAsync(roundId, memberId, operatorId, gameConfigs.Name).Returns(roundEntity);

            //Act
            var result = await gameBetService.GetAsync(roundId, memberId, operatorId, gameConfigs.Name);

            //Assert
            Assert.StrictEqual(roundEntity, result);
            gameBetRepository.Received(1).GetAsync(roundId, memberId, operatorId, gameConfigs.Name);
        }
    }
}