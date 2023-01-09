using System.Threading.Tasks;
using GameRoundResult.Core.Database;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.SlotGames
{
    public class BaseEndRoundService : IEndGameInfoService
    {
        private readonly IGameConfigsRepository gameConfigsRepository;
        private readonly ISlotGameBetRepository betRepository;

        public BaseEndRoundService(
            IGameConfigsRepository gameConfigsRepository,
            ISlotGameBetRepository betRepository)
        {
            this.gameConfigsRepository = gameConfigsRepository;
            this.betRepository = betRepository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var gameConfigs = await gameConfigsRepository.GetByIdAsync(request.GameTypeId);

            if (gameConfigs == null)
            {
                return EndRoundInfoError.SB1006;
            }

            var round = await GetRoundAsync<BaseSlotRoundEntity>(request, gameConfigs.Name);

            if (round == null)
            {
                return EndRoundInfoError.SB1001;
            }

            if (!round.Paid)
            {
                return EndRoundInfoError.SB1005;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.EndTime,
                ValidBetAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalWin = round.BetWin + round.Betwin
            };
        }

        protected Task<T> GetRoundAsync<T>(RetrieveEndGameInfoRequest request, string gameConfigName) where T : BaseSlotRoundEntity
        => betRepository.GetEndRoundAsync<T>(request.GameRoundId, request.PlayerId, request.OperatorId, gameConfigName, request.SiteId);
    }
}