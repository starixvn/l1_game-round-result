using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Extensions;
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
            var (round, bet, betLogs) = await crashGameTicketService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            var viewModel = new CrashGameTicketViewModel

            {
                GameId = gameConfigs.GameId,
                GameType = gameConfigs.Type,
                BetLogs = betLogs.Select(betLog => betLog.ToViewModel(mapper, request.TimeZoneInfo))
            };

            if (round != null)
            {
                viewModel.RoundResult = mapper.Map<CrashGameRoundResultViewModel>(round);
                viewModel.RoundResult.TimeZone = request.TimeZoneInfo;
            }

            if (bet != null)
            {
                viewModel.TotalBet = bet.Amount;
                viewModel.BetWin = bet.Betwin;
            }

            return viewModel;
        }
    }
}