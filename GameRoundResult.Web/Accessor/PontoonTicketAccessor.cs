using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class PontoonTicketAccessor : IGameTicketAccessor
    {
        private readonly IPontoonTicketService gameBetService;
        private readonly IMapper mapper;

        public PontoonTicketAccessor(IPontoonTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var pontoonResult = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            return new PontoonTicketViewModel
            {
                DealerCards = pontoonResult.Item1?.Result.Select(x => mapper.Map<CardViewModel>(x)),
                DealerPoint = pontoonResult.Item1?.SettlementResult ?? 0,
                Ended = pontoonResult.Item1?.Ended ?? false,
                Bet = pontoonResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo),
            };
        }
    }
}
