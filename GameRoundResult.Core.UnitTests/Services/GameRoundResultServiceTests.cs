using System;
using System.Linq;
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
    public class GameRoundResultServiceTests
    {
        private readonly IGameRoundResultService gameRoundService;
        private readonly IGameRoundRepository gameRoundRepository;
        private readonly Fixture fixture;

        public GameRoundResultServiceTests()
        {
            gameRoundRepository = Substitute.For<IGameRoundRepository>();
            gameRoundService = new GameRoundResultService(gameRoundRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GameRoundService_ReturnCorrectResult(DateTime date, long roundId, int page, int pageSize)
        {
            //Arrnage
            var roundEntities = fixture.CreateMany<SeDieRound>();
            gameRoundRepository.GetGameRoundResultAsync<SeDieRound>(date, roundId, page, pageSize)
                .Returns((roundEntities.Count(), roundEntities));

            //Act
            var result = await gameRoundService.GetGameRoundResultAsync<SeDieRound>(date, roundId, page, pageSize);

            //Assert
            Assert.StrictEqual(roundEntities.Count(), result.Item1);
            Assert.StrictEqual(roundEntities, result.Item2);
        }
    }
}
