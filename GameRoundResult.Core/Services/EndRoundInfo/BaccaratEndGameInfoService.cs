using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BaccaratEndGameInfoService<TBaseRoundEntity, TBaseBetEntity> : BaseEndGameInfoService<TBaseRoundEntity, TBaseBetEntity>, IEndGameInfoService
       where TBaseRoundEntity : BaseBaccaratRoundEntity
       where TBaseBetEntity : BaccaratBet
    {
        private readonly IGameBetRepository repository;
        public BaccaratEndGameInfoService(IMongoDatabase database, IGameBetRepository repository)
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
                return EndGameInfoError.SB1001;
            }

            var totalBetAmount = bets.Sum(x => x.Player + x.PlayerPair + x.Banker + x.BankerPair + x.Tie + x.Big + x.Small);
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