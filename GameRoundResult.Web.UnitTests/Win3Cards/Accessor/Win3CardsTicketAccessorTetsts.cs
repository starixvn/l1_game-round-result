using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using NSubstitute;
using Xunit;

namespace GameRoundResult.Web.UnitTests.Accessor
{
    public class Win3CardsTicketAccessorTetsts
    {
        private readonly Win3CardsTicketAccessor accessor;
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;
        private readonly Fixture fixture;

        public Win3CardsTicketAccessorTetsts()
        {
            gameBetService = Substitute.For<IGameBetService>();
            mapper = Substitute.For<IMapper>();
            currencyGroupService = Substitute.For<ICurrencyGroupService>();
            accessor = new Win3CardsTicketAccessor(gameBetService, mapper, currencyGroupService);
            fixture = new Fixture();
        }

        [Fact]
        public async Task GetAsync_NotExistBet_ReturnExpectedWithFrationalOddsFormatNull()
        {
            // arrange
            var round = Substitute.For<Win3CardsRound>();
            var request = fixture.Create<GetGameTicketRequest>();
            var roundResult = new Win3CardsRoundResultViewModel();
            gameBetService
                .GetAsync<Win3CardsRound, Win3CardsBet, Win3CardsBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId)
                .Returns((round, new List<Win3CardsBetLog>(), null));
            mapper
                .Map(round, Arg.Any<Action<IMappingOperationOptions<Win3CardsRound, Win3CardsRoundResultViewModel>>>())
                .Returns(roundResult);

            // act
            var actual = (Win3CardsTicketViewModel)await accessor.GetAsync(request);

            // assert
            round.Received().ToViewModel<Win3CardsRound, Win3CardsRoundResultViewModel>(mapper, request.TimeZoneInfo);
            Assert.Equal(roundResult, actual.RoundResult);
            Assert.Empty(actual.BetLogs);
            Assert.Equal(0, actual.TotalBet);
            Assert.Equal(0, actual.BetWin);
            Assert.Null(actual.FractionalOddsFormat);
        }

        [Fact]
        public async Task GetAsync_ExistBet_ReturnExpectedWithFrationalOddsFormat()
        {
            // arrange
            var round = Substitute.For<Win3CardsRound>();
            var request = fixture.Create<GetGameTicketRequest>();
            var roundResult = new Win3CardsRoundResultViewModel();
            var betlog = Substitute.For<Win3CardsBetLog>();
            gameBetService
                .GetAsync<Win3CardsRound, Win3CardsBet, Win3CardsBetLog>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId)
                .Returns((round, new List<Win3CardsBetLog> { betlog, betlog }, new Win3CardsBet { Dragon = 10, Phoenix = 10, Betwin = (decimal)19.5 }));
            mapper
                .Map(round, Arg.Any<Action<IMappingOperationOptions<Win3CardsRound, Win3CardsRoundResultViewModel>>>())
                .Returns(roundResult);
            currencyGroupService.GetFractionalOddsFormat(betlog.Currency, request.OperatorId).Returns(true);

            // act
            var actual = (Win3CardsTicketViewModel)await accessor.GetAsync(request);

            // assert
            round.Received().ToViewModel<Win3CardsRound, Win3CardsRoundResultViewModel>(mapper, request.TimeZoneInfo);
            betlog.Received().ToViewModel(mapper, request.TimeZoneInfo);
            Assert.Equal(roundResult, actual.RoundResult);
            Assert.Equal(2, actual.BetLogs.Count());
            Assert.Equal(20, actual.TotalBet);
            Assert.Equal((decimal)19.5, actual.BetWin);
            Assert.True(actual.FractionalOddsFormat);
        }
    }
}