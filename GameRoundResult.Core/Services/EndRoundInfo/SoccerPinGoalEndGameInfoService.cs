using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SoccerPinGoalEndGameInfoService
        : BaseEndGameInfoService<SoccerPinGoalRound, SoccerPinGoalBet>,
            IEndGameInfoService
    {
        public SoccerPinGoalEndGameInfoService(IMongoDatabase database)
            : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var soccerPinGoalRound = await GetRoundAsync(request);
            var soccerPinGoalBets = await GetBetsAsync(request);

            if (soccerPinGoalRound == null || !soccerPinGoalBets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = soccerPinGoalBets.Sum(x => x.TotalAmount);
            var totalBetWin = soccerPinGoalBets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = soccerPinGoalRound.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin,
            };
        }
    }
}
