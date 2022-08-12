using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class MiniSeDieTicketAccessor<TMiniSeDieRound, TMiniSeDieBet> : IGameTicketAccessor
        where TMiniSeDieRound : MiniSeDieRound
        where TMiniSeDieBet : MiniSeDieBet
    {
        private readonly IGameBetService gameBetService;
        private readonly IMapper mapper;

        public MiniSeDieTicketAccessor(IGameBetService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync<TMiniSeDieRound, TMiniSeDieBet>(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId);

            return new MiniSeDieTicketViewModel
            {
                RoundResult = result.Item1?.ToViewModel<TMiniSeDieRound, MiniSeDieRoundResultViewModel>(mapper, request.TimeZoneInfo),
                Bet = result.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
            };
        }
    }
}