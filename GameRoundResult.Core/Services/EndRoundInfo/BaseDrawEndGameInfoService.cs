using GameRoundResult.Core.Database.Entities.GameDraw;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services.EndRoundInfo
{
    public class BaseDrawEndGameInfoService<Round, Bet, Result, Settlement> : BaseEndGameInfoService<Round, Bet>, IEndGameInfoService
        where Round : GameDraw<Result, Settlement>
        where Bet : GameDrawBaseBetEntity
        where Result : GameDrawBase
    {
        public BaseDrawEndGameInfoService(IMongoDatabase database) : base(database) { }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);
            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.TotalBet);
            var totalBetWin = bets.Sum(x => x.Betwin);

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount = totalBetAmount,
                TotalAmount = totalBetAmount,
                TotalWin = totalBetWin
            };
        }

        protected override async Task<Round> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var roundFilter = Builders<Round>.Filter.ElemMatch(x => x.Result, y => y.DrawId == request.GameRoundId);
            var roundEntity = await roundCollection.Find(roundFilter).FirstOrDefaultAsync();

            return roundEntity;
        }

        protected override Expression<Func<Bet, bool>> GetBetFilterExpression(RetrieveEndGameInfoRequest request)
            => (bet) => bet.DrawId == request.GameRoundId && bet.PlayerId == request.PlayerId && bet.Paid;
    }
}
