using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class ChineseBlackjackTicketAccessor : IGameTicketAccessor
    {
        private readonly IChineseBlackjackTicketService gameBetService;
        private readonly IMapper mapper;

        public ChineseBlackjackTicketAccessor(IChineseBlackjackTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var ChineseBlackjackResult = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            return new ChineseBlackjackTicketViewModel
            {
                DealerCards = ChineseBlackjackResult.Item1?.Result.Select(x => mapper.Map<CardViewModel>(x)),
                DealerPoint = ChineseBlackjackResult.Item1?.SettlementResult ?? 0,
                Ended = ChineseBlackjackResult.Item1?.Ended ?? false,
                Bet = ChineseBlackjackResult.Item2?.ToViewModel(mapper, request.TimeZoneOffset),
            };
        }
    }
}
