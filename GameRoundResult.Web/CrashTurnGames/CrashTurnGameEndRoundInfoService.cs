using System.Threading.Tasks;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.CrashTurnGames
{
    public class CrashTurnGameEndRoundInfoService : IEndGameInfoService
    {
        private readonly ICrashTurnGameBetRepository betRepository;

        public CrashTurnGameEndRoundInfoService(
            ICrashTurnGameBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await betRepository.GetEndRoundAsync(request.GameRoundId, request.PlayerId, request.FreeBet, request.OperatorId, request.GameName);


            if (round == null)
            {
                return EndRoundInfoError.SB1001;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = round.Amount,
                TotalAmount = round.Amount,
                TotalWin = round.Betwin
            };
        }
    }
}