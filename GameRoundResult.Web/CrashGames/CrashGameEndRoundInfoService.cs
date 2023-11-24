using System.Threading.Tasks;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.CrashGames
{
    public class CrashGameEndRoundInfoService : IEndGameInfoService
    {
        private readonly ICrashGameBetRepository betRepository;

        public CrashGameEndRoundInfoService(
            ICrashGameBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var (round, bet) = await betRepository.GetEndRoundAsync(request.GameRoundId, request.PlayerId, request.OperatorId, request.GameName);
 

            if (round == null || bet == null)
            {
                return EndRoundInfoError.SB1001;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = bet.Amount,
                TotalAmount = bet.Amount,
                TotalWin = bet.Betwin
            };
        }
    }
}