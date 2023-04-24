using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class MiniKenoEndGameInfoService<TBaseRoundEntity, TBaseBetEntity> : BaseEndGameInfoService<TBaseRoundEntity, TBaseBetEntity>, IEndGameInfoService
       where TBaseRoundEntity : KenoRound
       where TBaseBetEntity : RNGKenoOnes
    {
        private readonly IGameBetRepository repository;
        public MiniKenoEndGameInfoService(IMongoDatabase database, IGameBetRepository repository)
           : base(database)
        {
            this.repository = repository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var result = await repository.GetAsync<TBaseRoundEntity, TBaseBetEntity>(request.GameRoundId, request.PlayerId, request.FreeBet, request.OperatorId);
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);

            if (round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.TotalAmount);
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