using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class MiniSeDieEndGameInfoService<TMiniSeDieRound, TMiniSeDieBet> : BaseEndGameInfoService<TMiniSeDieRound, TMiniSeDieBet>, IEndGameInfoService
        where TMiniSeDieRound: MiniSeDieRound
        where TMiniSeDieBet : MiniSeDieBet
    {
        public MiniSeDieEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndGameInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Odd + x.Even + x.ThreeRed + x.FourRed + x.ThreeWhite + x.FourWhite);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }
    }
}