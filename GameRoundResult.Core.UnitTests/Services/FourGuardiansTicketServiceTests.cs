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
    public class FourGuardiansTicketServiceTests
    {
        private readonly IFourGuardiansTicketService gameBetService;
        private readonly IFourGuardiansBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public FourGuardiansTicketServiceTests()
        {
            gameBetRepository = Substitute.For<IFourGuardiansBetRepository>();
            gameBetService = new FourGuardiansTicketService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(long roundId, int memberId, string operatorId)
        {
            //Arrnage
            var roundEntity = fixture.Create<FourGuardiansRound>();
            gameBetRepository.GetAsync<FourGuardiansRound>(roundId, memberId, operatorId).Returns(roundEntity);

            //Act
            var result = await gameBetService.GetAsync<FourGuardiansRound>(roundId, memberId, operatorId);

            //Assert
            Assert.StrictEqual(roundEntity, result);
            gameBetRepository.Received(1).GetAsync<FourGuardiansRound>(roundId, memberId, operatorId);
        }
    }
}