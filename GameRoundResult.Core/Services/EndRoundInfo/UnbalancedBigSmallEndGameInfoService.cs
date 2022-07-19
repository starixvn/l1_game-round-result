using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class UnbalancedBigSmallEndGameInfoService<TUnbalancedBigSmallRound, TUnbalancedBigSmallBet> : BaseEndGameInfoService<TUnbalancedBigSmallRound, TUnbalancedBigSmallBet>, IEndGameInfoService
        where TUnbalancedBigSmallRound : UnbalancedBigSmallRound
        where TUnbalancedBigSmallBet : UnbalancedBigSmallBet
    {
        public UnbalancedBigSmallEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bet = (await GetBetsAsync(request)).FirstOrDefault();

            if (round == null || bet == null)
            {
                return EndGameInfoError.SB1001;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = bet.TotalAmount,
                TotalAmount = bet.TotalAmount,
                TotalWin = bet.Betwin
            };
        }
    }
}