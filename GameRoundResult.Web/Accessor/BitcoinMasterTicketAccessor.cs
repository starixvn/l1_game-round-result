using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class BitcoinMasterTicketAccessor : IGameTicketAccessor
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public BitcoinMasterTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<BitcoinMasterRound, BitcoinMasterOne, BitcoinMasterBet>(request.RoundId, request.MemberId, request.FreeBet);

            return new BitcoinMasterTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                Bets = result.Item2?.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                TotalBet = result.Item3?.Amount ?? 0,
                TotalBetWin = result.Item3?.Betwin ?? 0,
                TotalRefund = result.Item3?.Refund ?? 0,
                Win = result.Item3?.Win ?? false
            };
        }
    }
}