using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.SlotGames
{
    public interface ISlotGameTicketService
    {
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName);
    }

    public class SlotGameTicketService : ISlotGameTicketService, IEndGameInfoService

    {
        private readonly ISlotGameBetRepository repository;
        private readonly IGameConfigsRepository gameConfigsRepository;

        public SlotGameTicketService(ISlotGameBetRepository repository, IGameConfigsRepository gameConfigsRepository)
        {
            this.repository = repository;
            this.gameConfigsRepository = gameConfigsRepository;
        }

        public async Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName)
        {
            return await repository.GetAsync(roundId, playerId, operatorId, gameName);
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var gameConfigs = await gameConfigsRepository.GetByIdAsync(request.GameTypeId);

            if (gameConfigs == null)
            {
                return EndRoundInfoError.SB1006;
            }

            var round = await GetRoundAsync(request, gameConfigs);

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
                TotalWin = round.BetWin
            };
        }

        protected Task<SlotGameRound> GetRoundAsync(RetrieveEndGameInfoRequest request, GameConfigs gameConfigs)
        => repository.GetEndRoundAsync(request.GameRoundId, request.PlayerId, request.OperatorId, gameConfigs.Name, request.SiteId);
    }
}