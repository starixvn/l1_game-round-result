using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class SoloBlackjackTicketAccessor : IGameTicketAccessor
    {
        private readonly ISoloBlackjackTicketService gameBetService;
        private readonly IMapper mapper;

        public SoloBlackjackTicketAccessor(ISoloBlackjackTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var soloBlackjackResult = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            return new SoloBlackjackTicketViewModel
            {
                DealerCards = soloBlackjackResult.Item1?.Result.Select(x => mapper.Map<CardViewModel>(x)),
                DealerPoint = soloBlackjackResult.Item1?.SettlementResult ?? 0,
                Ended = soloBlackjackResult.Item1?.Ended ?? false,
                Bet = soloBlackjackResult.Item2?.ToViewModel(mapper, request.TimeZoneOffset),
            };
        }
    }
}
