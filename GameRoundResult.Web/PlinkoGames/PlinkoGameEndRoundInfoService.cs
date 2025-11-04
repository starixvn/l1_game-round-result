using System.Threading.Tasks;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.PlinkoGames
{
    public class PlinkoGameEndRoundInfoService : IEndGameInfoService
    {
        private readonly IPlinkoGameBetRepository betRepository;

        public PlinkoGameEndRoundInfoService(
            IPlinkoGameBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await betRepository.GetAsync(request.GameRoundId, request.PlayerId, request.OperatorId, request.GameName);
 

            if (round == null)
            {
                return EndRoundInfoError.SB1001;
            }
            
            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = round.TotalAmount,
                TotalAmount = round.TotalAmount,
                TotalWin = round.BetWin
            };
        }
    }
}