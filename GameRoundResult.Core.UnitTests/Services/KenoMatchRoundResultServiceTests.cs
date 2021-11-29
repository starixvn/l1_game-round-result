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
    public class KenoMatchRoundResultServiceTests
    {
        private readonly IKenoMatchRoundResultService gameRoundService;
        private readonly IGameRoundRepository gameRoundRepository;
        private readonly Fixture fixture;

        public KenoMatchRoundResultServiceTests()
        {
            gameRoundRepository = Substitute.For<IGameRoundRepository>();
            gameRoundService = new KenoMatchRoundResultService(gameRoundRepository);
            fixture = new Fixture();
        }

        [Theory, AutoData]
        public async Task GetAsync_ReturnCorrectResult(DateTime date, long roundId, int page, int pageSize)
        {
            //Arrnage
            var roundEntities = fixture.CreateMany<KenoMatchRound>();
            gameRoundRepository.GetGameRoundResultAsync(date, roundId, page, pageSize, Arg.Any<Expression<Func<KenoMatchRound, bool>>>())
                .Returns((roundEntities.Count(), roundEntities));

            //Act
            var result = await gameRoundService.GetGameRoundResultAsync<KenoMatchRound>(date, roundId, page, pageSize);

            //Assert
            Assert.StrictEqual(roundEntities.Count(), result.Item1);
            Assert.StrictEqual(roundEntities, result.Item2);
        }
    }
}
