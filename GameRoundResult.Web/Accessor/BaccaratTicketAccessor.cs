using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class BaccaratTicketAccessor<TBaseRoundEntity, TBaseBetEntity> : IGameTicketAccessor
          where TBaseRoundEntity : BaseBaccaratRoundEntity
        where TBaseBetEntity : BaccaratBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public BaccaratTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request, GameConfigModel gameConfigs)
        {
            var result = await gameBetService.GetAsync<TBaseRoundEntity, TBaseBetEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new BaccaratTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TBaseRoundEntity, BaccaratRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}