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
    public class BlackjackTicketServiceTests
    {
        private readonly IBlackjackTicketService gameBetService;
        private readonly IBlackjackBetRepository gameBetRepository;
        private readonly Fixture fixture;

        public BlackjackTicketServiceTests()
        {
            gameBetRepository = Substitute.For<IBlackjackBetRepository>();
            gameBetService = new BlackjackTicketService(gameBetRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(long handId, int memberId, string partnerId)
        {
            //Arrnage
            var roundEntity = fixture.Create<BlackjackRound>();
            var betEntity = fixture.Create<BlackjackBet>();
            gameBetRepository.GetAsync(handId, memberId, partnerId).Returns((roundEntity, betEntity));

            //Act
            var result = await gameBetService.GetAsync(handId, memberId, partnerId);

            //Assert
            Assert.StrictEqual(roundEntity, result.Item1);
            Assert.StrictEqual(betEntity, result.Item2);
            gameBetRepository.Received(1).GetAsync(handId, memberId, partnerId);
        }
    }
}