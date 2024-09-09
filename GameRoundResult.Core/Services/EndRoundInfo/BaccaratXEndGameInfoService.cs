using System;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class BaccaratXEndGameInfoService<TBaseRoundEntity, TBaseBetEntity> : BaseEndGameInfoService<TBaseRoundEntity, TBaseBetEntity>, IEndGameInfoService
       where TBaseRoundEntity : BaccaratXRound
       where TBaseBetEntity : BaccaratXBet
    {
        private readonly IGameBetRepository repository;
        public BaccaratXEndGameInfoService(IMongoDatabase database, IGameBetRepository repository)
           : base(database)
        {
            this.repository = repository;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);
            var bets = await GetBetsAsync(request);


            if(round == null || !bets.Any())
            {
                return EndRoundInfoError.SB1001;
            }

            var bet = bets.FirstOrDefault();

            return new EndRoundInfoResult
            {
                EndTime = round.Time,
                ValidBetAmount =  Math.Round(bet.TotalAmount,2),
                TotalAmount = Math.Round(bet.TotalAmount, 2),
                TotalWin = bet.Betwin
            };
        }
    }
}