using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class BlackjackTicketAccessor : IGameTicketAccessor
    {
        private readonly IBlackjackTicketService gameBetService;
        private readonly IMapper mapper;

        public BlackjackTicketAccessor(IBlackjackTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var blackjackResult = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            return new BlackjackTicketViewModel
            {
                DealerCards = blackjackResult.Item1?.Result.Select(x => mapper.Map<CardViewModel>(x)),
                DealerPoint = blackjackResult.Item1?.SettlementResult ?? 0,
                Ended = blackjackResult.Item1?.Ended ?? false,
                Bet = blackjackResult.Item2?.ToViewModel(mapper, request.TimeZoneOffset),
            };
        }
    }
}
