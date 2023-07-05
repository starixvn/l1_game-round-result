using AutoMapper;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class DragonTigerFightTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public DragonTigerFightTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<DragonTigerFightRound, DragonTigerFightOne>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new DragonTigerFightTicketViewModel
                {
                    RoundResult = result.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                    Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                };            
        }
    }
}