using System;
using System.Linq;
using System.Linq.Expressions;
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
    public class KenoSoccerRoundResultServiceTests
    {
        private readonly IKenoSoccerRoundResultService gameRoundService;
        private readonly IGameRoundRepository gameRoundRepository;
        private readonly Fixture fixture;

        public KenoSoccerRoundResultServiceTests()
        {
            gameRoundRepository = Substitute.For<IGameRoundRepository>();
            gameRoundService = new KenoSoccerRoundResultService(gameRoundRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(DateTime date, long roundId, int page, int pageSize)
        {
            //Arrnage
            var roundEntities = fixture.CreateMany<KenoSoccerRound>();
            gameRoundRepository.GetGameRoundResultAsync(date, roundId, page, pageSize, Arg.Any<Expression<Func<KenoSoccerRound, bool>>>())
                .Returns((roundEntities.Count(), roundEntities));

            //Act
            var result = await gameRoundService.GetGameRoundResultAsync<KenoSoccerRound>(date, roundId, page, pageSize);

            //Assert
            Assert.StrictEqual(roundEntities.Count(), result.Item1);
            Assert.StrictEqual(roundEntities, result.Item2);
        }
    }
}
