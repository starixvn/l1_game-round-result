using AutoMapper;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.CrashGames;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;
using GameRoundResult.Web.PlinkoXGames.ViewModels;

namespace GameRoundResult.Web.PlinkoXGames
{
    public class PlinkoXGameHandler : IGameTicketAccessor
    {
        private readonly IPlinkoXGameTicketService plinkoXGameTicketService;
        private readonly IMapper mapper;

        public PlinkoXGameHandler(
            IPlinkoXGameTicketService gameBetService,
            IMapper mapper)
        {
            plinkoXGameTicketService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = request.GameConfigs;
            var round = await plinkoXGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new PlinkoXGameTicketViewModel
            {
                GameId = gameConfigs.GameId,
                GameType = gameConfigs.Type,
            };

            if (round != null)
            {
                viewModel.RoundResult = mapper.Map<PlinkoXGameRoundResultViewModel>(round);
                viewModel.RoundResult.TimeZoneOffset = request.TimeZoneOffset;
                viewModel.TotalBet = round.TotalAmount;
                viewModel.BetWin = round.BetWin;
                viewModel.Rate = round.Rate;
            }

            return viewModel;
        }
    }
}
