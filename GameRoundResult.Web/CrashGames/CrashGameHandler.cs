using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.CrashGames.Handlers
{
    public class CrashGameHandler : IGameTicketAccessor
    {
        private readonly ICrashGameTicketService crashGameTicketService;
        private readonly IMapper mapper;

        public CrashGameHandler(
            ICrashGameTicketService gameBetService,
            IMapper mapper)
        {
            crashGameTicketService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var gameConfigs = request.GameConfigs;
            var result = await crashGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new CrashGameTicketViewModel

            {
                GameId = gameConfigs.GameId,
                GameType = gameConfigs.Type,
                BetLogs = mapper.Map<IEnumerable<CrashGameBetLogViewModel>>(result.Item3)
            };

            if (result.Item1 != null)
            {
                viewModel.RoundResult = mapper.Map<CrashGameRoundResultViewModel>(result);
                viewModel.RoundResult.TimeZone = request.TimeZoneInfo;
            }

            if (result.Item2 != null)
            {
                viewModel.TotalBet = result.Item2.Amount;
                viewModel.BetWin = result.Item2.Betwin;
            }

            return viewModel;
        }
    }
}