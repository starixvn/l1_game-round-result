using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SicBoEndGameInfoService : BaseEndGameInfoService<SicBoRound, SicBoOne>, IEndGameInfoService
    {
        public SicBoEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndGameInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var one = (await GetBetsAsync(request)).FirstOrDefault();

            if (round == null || one == null)
            {
                return EndGameInfoError.SB1001;
            }

            return new EndGameInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = one.TotalAmount,
                TotalAmount = one.TotalAmount,
                TotalWin = one.Betwin
            };
        }
    }
}