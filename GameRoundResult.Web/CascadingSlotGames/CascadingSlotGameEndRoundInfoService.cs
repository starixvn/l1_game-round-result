using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.CascadingSlotGames
{
    public class CascadingSlotGameEndRoundInfoService : IEndGameInfoService
    {
        private readonly ICascadingSlotBetRepository betRepository;

        public CascadingSlotGameEndRoundInfoService(
            ICascadingSlotBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request, request.GameName);

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
                TotalWin = round.Betwin
            };
        }

        protected Task<BaseCascadingSlotRoundEntity> GetRoundAsync(RetrieveEndGameInfoRequest request, string gameConfigName)
            => betRepository.GetEndRoundAsync(request.GameRoundId, request.PlayerId, request.OperatorId, gameConfigName);
    }
}