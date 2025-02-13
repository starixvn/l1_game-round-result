using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities.SevenUpDown;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models.GameTicket;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.CoinMining;
using MongoDB.Driver.Linq;

namespace GameRoundResult.Web.Accessor
{
    public class CoinMiningAccessor<TOneEntity, TBetEntity> : IGameTicketAccessor
        where TOneEntity : CoinMiningBet
        where TBetEntity : CoinMiningBetLog

    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public CoinMiningAccessor(IGameBetService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetBetAsync<TOneEntity, TBetEntity>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameConfigs.Name);

            return new CoinMiningTicketViewModel
            {
                Bet = result.Item1,
                Time = result.Item1.Time.AddHours(request.TimeZoneOffset.TotalHours),
                BetLogs = result.Item2.Select(x => x.ToBetLogViewModel<TBetEntity, CoinMiningBetLogViewModel>(mapper, request.TimeZoneOffset))
            };
        }

    }
}
