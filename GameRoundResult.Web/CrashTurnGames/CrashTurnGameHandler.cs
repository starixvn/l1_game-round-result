using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CrashTurnGames.ViewModels;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System.Threading.Tasks;

namespace GameRoundResult.Web.CrashTurnGames.Handlers
{
    public class CrashTurnGameHandler : IGameTicketAccessor
    {
        private readonly ICrashTurnGameBetRepository gameBetService;

        public CrashTurnGameHandler(ICrashTurnGameBetRepository gameBetService)
        {

            this.gameBetService = gameBetService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetBetAsync(request.RoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameConfigs.Name);
            var viewModel = new CrashTurnGameTicketViewModel
            {
                Bet = result.Item1,
                GameType = request.GameConfigs.Type
            };
            return viewModel;
        }
    }
}