using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class CasinoHoldemPokerTicketAccessor<TRoundEntity, TBetEntity> : IGameTicketAccessor
        where TRoundEntity : CasinoHoldemPokerRound
        where TBetEntity : CasinoHoldemPokerBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public CasinoHoldemPokerTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TRoundEntity, TBetEntity>(request.RoundId, request.MemberId, request.FreeBet);

            return new CasinoHoldemPokerTicketViewModel
            {
            };
        }
    }
}