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
    public class BaseCascadingSlotTicketServiceTests
    {
        private readonly IBaseCascadingSlotTicketService gameBetService;
        private readonly IBaseCascadingSlotBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public BaseCascadingSlotTicketServiceTests()
        {
            gameBetRepository = Substitute.For<IBaseCascadingSlotBetRepository>();
            gameBetService = new BaseCascadingSlotTicketService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(long roundId, int memberId, string operatorId)
        {
            //Arrnage
            var roundEntity = fixture.Create<BaseCascadingSlotRoundEntity>();
            var totalMultiplierEntity = fixture.Create<BaseCascadingSlotTotalMultiplierEntity>();
            gameBetRepository.GetAsync<BaseCascadingSlotRoundEntity , BaseCascadingSlotTotalMultiplierEntity> (roundId, memberId, operatorId).Returns((roundEntity, totalMultiplierEntity));

            //Act
            var result = await gameBetService.GetAsync<BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity>(roundId, memberId, operatorId);

            //Assert
            Assert.StrictEqual(roundEntity, result.Item1);
            Assert.StrictEqual(totalMultiplierEntity, result.Item2);
            await gameBetRepository.Received(1).GetAsync<BaseCascadingSlotRoundEntity, BaseCascadingSlotTotalMultiplierEntity>(roundId, memberId, operatorId);
        }
    }
}