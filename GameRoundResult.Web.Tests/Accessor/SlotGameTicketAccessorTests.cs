using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using NSubstitute;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Accessor
{
    public class SlotGameTicketAccessorTests
    {
        private readonly SlotGameTicketAccessor accessor;
        private readonly ISlotGameTicketService slotGameTicketService;
        private readonly IGameConfigsService gameConfigsService;
        private readonly IMapper mapper;
        private readonly Fixture fixture;

        public SlotGameTicketAccessorTests()
        {
            slotGameTicketService = Substitute.For<ISlotGameTicketService>();
            gameConfigsService = Substitute.For<IGameConfigsService>();
            mapper = Substitute.For<IMapper>();
            accessor = new SlotGameTicketAccessor(slotGameTicketService, gameConfigsService, mapper);
            fixture = new Fixture();
        }

        [Fact]
        public async Task GetAsync_NotFoundGameConfigs_ShouldReturnNull()
        {
            //Arrnage
            var request = fixture.Create<GetGameTicketRequest>();

            //Act
            var result = await accessor.GetAsync(request);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAsync_GameConfigsAvailable_ShouldReturnResult()
        {
            //Arrnage
            var request = fixture.Create<GetGameTicketRequest>();
            var gameConfigs = fixture.Create<GameConfigs>();
            var round = fixture.Create<SlotGameRound>();

            gameConfigsService.GetByIdAsync((int)request.GameType).Returns(gameConfigs);
            slotGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name).Returns(round);
            mapper.Map<SlotGameRound, SlotGameRoundResultViewModel>(round).Returns(fixture.Create<SlotGameRoundResultViewModel>());

            //Act
            var result = await accessor.GetAsync(request);

            //Assert
            var model = Assert.IsType<SlotGameTicketViewModel>(result);
            Assert.Equal(request.SystemType, model.SystemType);
            Assert.Equal(gameConfigs.SlotsConfig.Jackpot.Enabled, model.EnabledJackpot);
            Assert.Equal(gameConfigs.Name, model.ConfigName);
        }
    }
}