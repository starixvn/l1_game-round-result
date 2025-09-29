using AutoMapper;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.CrashGames;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;
using GameRoundResult.Web.PlinkoGames.ViewModels;

namespace GameRoundResult.Web.PlinkoGames
{
    public class PlinkoGameHandler : IGameTicketAccessor
    {
        private readonly IPlinkoGameTicketService plinkoGameTicketService;
        private readonly IMapper mapper;

        public PlinkoGameHandler(
            IPlinkoGameTicketService gameBetService,
            IMapper mapper)
        {
            plinkoGameTicketService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = request.GameConfigs;
            var round = await plinkoGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new PlinkoGameTicketViewModel
            {
                GameId = gameConfigs.GameId,
                GameType = gameConfigs.Type,
            };

            if (round != null)
            {
                viewModel.RoundResult = mapper.Map<PlinkoGameRoundResultViewModel>(round);
                viewModel.RoundResult.TimeZoneOffset = request.TimeZoneOffset;
                viewModel.TotalBet = round.TotalAmount;
                viewModel.BetWin = round.BetWin;
            }

            return viewModel;
        }
    }
}
