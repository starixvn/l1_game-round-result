using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.SeDieMultiplayer;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SeDieMultiplayerEndGameInfoService : BaseEndGameInfoService<SeDieMultiplayerRound, SeDieMultiplayerBet>, IEndGameInfoService
    {
        public SeDieMultiplayerEndGameInfoService(IMongoDatabase database) : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var sedieMultiplayerRound = await GetRoundAsync(request);
            var sedieMultiplayerBets  = await GetBetsAsync(request);

            if (sedieMultiplayerRound == null || !sedieMultiplayerBets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var sedieMultiplayerTotalBetAmount = sedieMultiplayerBets.Sum(x => x.Odd + x.Even + x.TwoRed + x.ThreeRed + x.FourRed + x.ThreeWhite + x.FourWhite);
            var sedieMultiplayerTotalBetWin    = sedieMultiplayerBets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime        = sedieMultiplayerRound.Time,
                ValidBetAmount = request.FreeBet ? 0 : sedieMultiplayerTotalBetAmount,
                TotalAmount    = request.FreeBet ? 0 : sedieMultiplayerTotalBetAmount,
                TotalWin       = sedieMultiplayerTotalBetWin
            };
        }

        protected override Expression<Func<SeDieMultiplayerBet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => base.GetBetFilterExpression(request).And(FreeBetExpression(request));
    }
}
